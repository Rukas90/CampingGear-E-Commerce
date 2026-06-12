using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Stripe;
using TrailStore.Domain.Orders.Errors;
using TrailStore.Domain.Orders.Interfaces;
using TrailStore.Domain.Orders.Models;
using TrailStore.Domain.Orders.Requests;
using TrailStore.Domain.Orders.Results;
using TrailStore.Domain.Payments.Interfaces;
using TrailStore.Domain.Payments.Models;
using TrailStore.Domain.Shared.Financials;
using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.Skus.Errors;
using TrailStore.Domain.Skus.Exceptions;
using TrailStore.Domain.Skus.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Orders;

[AppService<IOrderService>]
public class OrderService(
    IOrderRepository orderRepository,
    IOrderItemRepository orderItemRepository,
    IPaymentService paymentService, 
    IStockReservationRepository stockReservationRepository,
    ISkuRepository skuRepository,
    IPaymentRepository paymentRepository,
    ILogger<IOrderService> logger,
    IOptions<OrderSettings> settings,
    IUnitOfWork unitOfWork) 
    : IOrderService
{
    private readonly string TokenSecretKey = settings.Value.TokenSecretKey;

    public async Task<Result<TResult>> GetOrder<TResult>(
        string token, Expression<Func<Order, TResult>> selector, CancellationToken ct)
    {
        var order = await orderRepository.FindByTokenAsync(token, selector, ct);

        if (order is null)
        {
            return OrderProblems.NotFound;
        }

        return order;
    }
    
    public async Task<Result<CreateOrderResult>> CreateOrder(CreateOrderRequest request, CancellationToken ct)
    {
        try
        {
            await using var scope = await unitOfWork.BeginScope(ct);
            
            var subtotal = request.Items.Sum(item => item.UnitPrice * item.Quantity);
            var financials = FinancialsCalculator.Calculate(input: new FinancialsCalculationsInput
            {
                Subtotal = subtotal,
                TaxRate = request.Country.TaxRate,
                ShippingFlatFee = request.ShippingMethod.FlatFee,
                FreeShippingThreshold = request.ShippingMethod.FreeShippingThreshold,
            });

            var orderId = Id<Order>.New();
            var order = orderRepository.Add(Order.Create(
                id: orderId,
                token: GenerateToken(orderId),
                request.EmailAddress, 
                financials.Total,
                financials.Tax,
                request.ShippingAddress, 
                request.BillingAddress,
                request.CustomerId));
            
             CreateOrderItems(order.Id, request.Items);
             
             await ReserveItemsStock(order.Id, request.Items, ct);
             await AddNewOrderPayment(order, ct);

             await scope.CompleteAsync();

             return new CreateOrderResult(orderId, order.Token);
        }
        catch (InsufficientStockException e)
        {
            logger.LogWarning("Sku by id {SkuId} could not reserve stock due to insufficient available stock.", e.SkuId.Value);
            
            return SkuProblems.InsufficientStock;
        }
        catch (SkuNotFoundException e)
        {
            logger.LogWarning("Sku by id {SkuId} was not found when trying to reserve stock.", e.SkuId.Value);
            
            return SkuProblems.InvalidSku;
        }
        catch (StripeException e)
        {
            logger.LogError(e, "Stripe payment intent initialization failed during order creation.");

            //TODO Stripe error/problem
            return SkuProblems.InvalidSku; 
        }
        catch (Exception e)
        {
            logger.LogError(e, "Unexpected error during order creation.");
            
            //TODO Unexpected error/problem
            return SkuProblems.InvalidSku;
        }
    }

    private void CreateOrderItems(Id<Order> orderId, IReadOnlyList<OrderLineItem> items)
    {
        orderItemRepository.AddRange(
            items.Select(item => OrderItem.Create(orderId, item.SkuId, item.Quantity, item.UnitPrice)));
    }

    private async Task ReserveItemsStock(Id<Order> orderId, IReadOnlyList<OrderLineItem> items, CancellationToken ct)
    {
        foreach (var (skuId, skuCode, _, reserveAmount) in items)
        {
            var sku = await skuRepository.FindByCodeAsync(skuCode, ct);

            if (sku == null)
            {
                throw new SkuNotFoundException(skuId);
            }

            sku.Reserve(reserveAmount);
            
            stockReservationRepository.Add(
                StockReservation.Create(skuId, reserveAmount, orderId.ToString(), TimeSpan.FromMinutes(15)));
        }
    }

    private async Task AddNewOrderPayment(Order order, CancellationToken ct)
    {
        var intent = await paymentService.CreateIntent(new PaymentIntentCreateData
        {
            OrderId = order.Id,
            Amount = order.TotalPrice
        }, ct);
        
        paymentRepository.Add(
            Payment.Create(order.Id, intent.Id, order.TotalPrice));
    }
    
    private string GenerateToken(Id<Order> orderId)
    {
        var key = Encoding.UTF8.GetBytes(TokenSecretKey);
        var data = Encoding.UTF8.GetBytes(orderId.ToString());
        
        var hash = HMACSHA256.HashData(key, data);
        
        return Convert.ToHexString(hash[..16]).ToLower();
    }
}