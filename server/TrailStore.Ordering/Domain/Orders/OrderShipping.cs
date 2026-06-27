using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public class OrderShipping : IModel<OrderShipping>
{
    public required Id<OrderShipping> Id { get; init; }
    public required Id<Order> OrderId { get; init; }
    public required string MethodCode { get; init; }
    public required string MethodName { get; init; }
    public required decimal Price { get; init; }
    public required PostalAddress Address { get; init; }

    public static OrderShipping Create(
        Id<Order> orderId, string methodCode, string methodName, decimal price, PostalAddress address)
        => new()
        {
            Id = Id<OrderShipping>.New(),
            OrderId = orderId,
            MethodCode = methodCode,
            MethodName = methodName,
            Price = price,
            Address = address
        };
}