using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class OrderItem : IModel<OrderItem>
{
    public required Id<OrderItem> Id { get; init; }
    public required Id<Order> OrderId { get; init; }
    public required Id<Sku> SkuId { get; init; }
    public required int Quantity { get; init; }
    public required decimal UnitPrice { get; init; }

    public Sku Sku { get; private set; } = null!;

    public static OrderItem Create(Id<Order> orderId, Id<Sku> skuId, int quantity, decimal unitPrice)
        => new()
        {
            Id = Id<OrderItem>.New(),
            OrderId = orderId,
            SkuId = skuId,
            Quantity = quantity,
            UnitPrice = unitPrice,
        };
}