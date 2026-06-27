using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public class OrderItem : IModel<OrderItem>
{
    public required Id<OrderItem> Id { get; init; }
    public required Id<Order> OrderId { get; init; }
    public required Id<SkuRef> SkuId { get; init; }
    public required int Quantity { get; init; }
    public required decimal UnitPrice { get; init; }
    
    public static OrderItem Create(Id<Order> orderId, Id<SkuRef> skuId, int quantity, decimal unitPrice)
        => new()
        {
            Id = Id<OrderItem>.New(),
            OrderId = orderId,
            SkuId = skuId,
            Quantity = quantity,
            UnitPrice = unitPrice,
        };
}