using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class OrderItem : IModel<OrderItem>
{
    public required Id<OrderItem> Id        { get; init; }
    public required Id<Order>     OrderId   { get; init; }
    public required Id<Sku>       SkuId     { get; init; }
    public required int           Quantity  { get; init; }
    public required decimal       UnitPrice { get; init; }

    public Order Order { get; private set; } = null!;
    public Sku   Sku   { get; private set; } = null!;
}