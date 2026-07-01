using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public class OrderShipping : IModel<OrderShipping>
{
    public required Id<OrderShipping> Id { get; init; }
    public required Id<Order> OrderId { get; init; }
    public required Id<ShippingMethod>? ShippingMethodId { get; init; }
    public required string MethodCode { get; init; }
    public required string MethodName { get; init; }
    public required decimal PriceBeforeTax { get; init; }
    public required decimal TaxAmount { get; init; }
    public required decimal PriceAfterTax { get; init; }
    public required ShippingAddress Address { get; init; }

    public static OrderShipping Create(
        Id<Order> orderId, 
        Id<ShippingMethod>? shippingMethodId,
        string methodCode, string methodName, 
        decimal priceBeforeTax, decimal taxAmount, decimal priceAfterTax,
        ShippingAddress address)
        => new()
        {
            Id = Id<OrderShipping>.New(),
            OrderId = orderId,
            ShippingMethodId = shippingMethodId,
            MethodCode = methodCode,
            MethodName = methodName,
            PriceBeforeTax = priceBeforeTax,
            TaxAmount = taxAmount,
            PriceAfterTax = priceAfterTax,
            Address = address
        };
}