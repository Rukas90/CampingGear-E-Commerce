using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
    IOrderShippingRepository orderShippingRepository,
    ILogger<IOrderService> logger,
    IOptions<OrderSettings> settings,
    IUnitOfWork unitOfWork) 
    : IOrderService
{
    private readonly string TokenSecretKey = settings.Value.TokenSecretKey;

    public async Task<Result<OrderSummary>> GetOrderSummary(string token, CancellationToken ct)
    {
        var summary = await orderRepository.FindByTokenAsync(token, order => new OrderSummary
        {
            TotalPrice = order.TotalPrice,
            Subtotal = order.Items.Sum(item => item.UnitPrice * item.Quantity),
            TaxAmount = order.TaxAmount,
            Status = order.Status,
            ShippingAmount = 69_420,
            ShippingMethod = "lol",
            ExhaustedPaymentAttempts = order.PaymentAttempts >= order.MaxPaymentAttempts,
            HasPendingPayment = order.ActivePayment != null && order.ActivePayment.ExpiresAt< DateTimeOffset.UtcNow,
            Items = order.Items.Select(item => new OrderItemSummary
            {
                SkuCode = item.Sku.Code,
                ProductName = item.Sku.Product.Name,
                VariantLine = string.Join(", ", item.Sku.Options.Select(option => option.Name)),
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                ImageUrl = item.Sku.Product.ThumbnailUrl
            })
            
        }, ct);

        if (summary is null)
        {
            return OrderProblems.NotFound;
        }
        
        

        return summary;
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
                request.BillingAddress,
                request.CustomerId));
            
             CreateOrderItems(order.Id, request.Items);
             
             await ReserveItemsStock(order.Id, request.Items, ct);
             await AddNewOrderPayment(order, ct);

             orderShippingRepository.Add(OrderShipping.Create(
                 order.Id,
                 request.ShippingMethod.Code,
                 request.ShippingMethod.Name,
                 financials.ShippingCost,
                 request.ShippingAddress));

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