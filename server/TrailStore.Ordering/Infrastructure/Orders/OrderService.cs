using TrailStore.Basket.Contracts.Carts;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Financials;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Infrastructure.Orders;

[AppService<IOrderService>]
public sealed class OrderService(
    ICartService cartService,
    IShippingMethodRepository shippingMethodRepository,
    IOrderRepository orderRepository) : IOrderService
{
    public Order CreateOrder(CreateOrderRequest request)
    {
        var orderId = Id<Order>.New();
        
        var orderShipping = OrderShipping.Create(
            orderId, 
            request.ShippingInfo.MethodId,
            request.ShippingInfo.Code, 
            request.ShippingInfo.Name, 
            request.ShippingInfo.Financials.CostBeforeTaxes,
            request.ShippingInfo.Financials.TaxAmount,
            request.ShippingInfo.Financials.CostAfterTaxes,
            request.ShippingInfo.Address);

        var items = request.Items
            .Select(item => OrderItem.Create(orderId, item))
            .ToArray();

        return orderRepository.Add(Order.Create(new OrderCreationInput
        {
            Id = orderId,
            Token = OrderTokenization.GenerateToken(),
            UserId = request.UserId,
            Status = OrderStatus.Pending,
            EmailAddress = request.EmailAddress,
            BillingAddress = request.BillingAddress,
            Financials = request.Financials,
            Shipping = orderShipping,
            Items = items
        }));
    }
    
    public async Task<Result<CreateOrderRequest>> BuildOrderCreationInput(Id<CartRef> cartId,
        ValidatedCheckoutInformation information, CancellationToken ct)
    {
        var cart = await cartService.GetCart(cartId, ct);

        if (cart is null or { Items.Length: <= 0 })
        {
            return CheckoutProblems.EmptyCart;
        }
        
        var shippingMethod = await shippingMethodRepository.FindAsync(information.ShippingMethodId, ct);

        if (shippingMethod is null)
        {
            return CheckoutProblems.InvalidShippingMethod;
        }

        var taxRate = information.Country.TaxRate;
        
        var lineItems = cart.Items.Select(item => new OrderLineItem(
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
            Address = information.ShippingAddress,
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
        
        return new CreateOrderRequest
        {
            UserId = cart.UserId,
            EmailAddress = information.EmailAddress,
            BillingAddress = information.BillingAddress,
            Country = information.Country,
            Items = lineItems,
            ShippingInfo = shipping,
            Financials = financials,
            CurrencyCode = CurrencyCode
        };
    }
}