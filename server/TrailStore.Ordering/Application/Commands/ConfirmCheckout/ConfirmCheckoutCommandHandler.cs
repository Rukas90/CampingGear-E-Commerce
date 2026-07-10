using TrailStore.Basket.Contracts.Carts;
using TrailStore.Inventory.Contracts;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Contracts.IntegrationEvents;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Financials;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Payments.Contracts.Payments;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Commands.ConfirmCheckout;

[AppService<ConfirmCheckoutCommandHandler>]
public sealed class ConfirmCheckoutCommandHandler(
    ICartService cartService,
    IShippingMethodRepository shippingMethodRepository,
    ICheckoutSessionService checkoutSessionService,
    IOrderService orderService,
    IOrderingUnitOfWork unitOfWork,
    IOrderingOutbox outbox,
    IInventoryService inventoryService,
    IPaymentService paymentService)
    : ICommandHandler<ConfirmCheckoutCommand, OrderCreatedResult>
{
    public async Task<Result<OrderCreatedResult>> Handle(ConfirmCheckoutCommand command, CancellationToken ct)
    {
        var result = await checkoutSessionService.FindCheckoutSession(command.Ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var checkoutSession = result.Value;
        
        var validation = CheckoutSessionValidator.Validate(checkoutSession);

        if (!validation.IsSuccess)
        {
            return validation.Problem;
        }

        var validatedCheckout = validation.Value;

        var items = await cartService.GetCartItems(command.Ctx, ct);

        if (items.Length <= 0)
        {
            return CheckoutProblems.EmptyCart;
        }
        
        var shippingMethod = await shippingMethodRepository.FindAsync(validatedCheckout.ShippingMethodId, ct);

        if (shippingMethod is null)
        {
            return CheckoutProblems.InvalidShippingMethod;
        }

        var taxRate = validatedCheckout.Country.TaxRate;
        
        var lineItems = items.Select(item => new OrderLineItem(
            item.SkuId, 
            item.BrandName,
            item.ProductName,
            item.VariantLine,
            item.UnitPrice,
            item.Quantity,
            item.ThumbnailUrl,
            FinancialsCalculator.CalculateLine(new LineFinancialsCalculationInput
            {
                UnitPrice = item.UnitPrice,
                TaxRate = taxRate,
                Quantity = item.Quantity
            }))).ToArray();

        var lineFinancials = lineItems.Select(item => item.Financials).ToArray();
        
        var shipping = new ShippingInfo
        {
            MethodId = shippingMethod.Id,
            Name = shippingMethod.Name,
            Code = shippingMethod.Code,
            Address = validatedCheckout.ShippingAddress,
            Financials = FinancialsCalculator.CalculateShipping(new ShippingFinancialsCalculationsInput
            {
                Lines = lineFinancials,
                TaxRate = taxRate,
                ShippingFlatFee = shippingMethod.FlatFee,
                FreeShippingThreshold = shippingMethod.FreeShippingThreshold
            })
        };

        var financials = FinancialsCalculator.CalculateOrder(new OrderFinancialsCalculationsInput
        {
            Lines = lineFinancials,
            Shipping = shipping.Financials
        });
        
        const string CurrencyCode = "eur"; // Currently predefined default currency
        
        var request = new CreateOrderRequest
        {
            UserId = checkoutSession.UserId,
            EmailAddress = validatedCheckout.EmailAddress,
            BillingAddress = validatedCheckout.BillingAddress,
            Country = validatedCheckout.Country,
            Items = lineItems,
            ShippingInfo = shipping,
            Financials = financials,
            CurrencyCode = CurrencyCode
        };
        
        var order = orderService.CreateOrder(request);

        var reservation = await inventoryService.ReserveStock(
            lineItems.Select(item => new StockReserveItem(item.SkuId, item.Quantity)).ToArray(), ct);

        if (!reservation.IsSuccess)
        {
            return reservation.Problem;
        }
        
        await paymentService.CreatePayment(
            new PaymentCreationInput(order.Id, order.TotalPrice, CurrencyCode, MaxAttempts: 3), ct);

        outbox.Enqueue(new OrderCreatedIntegrationEvent(command.Ctx.OwnerId, command.Ctx.SessionId));
        
        await unitOfWork.SaveAsync(ct);
        
        return Result.Success(new OrderCreatedResult(order.Id));
    }
}