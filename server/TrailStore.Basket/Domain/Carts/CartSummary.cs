using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Carts;

public sealed class CartSummary
{
    public Id<Cart>? CartId { get; init; }
    public int ItemsCount { get; init; }
    
    public static CartSummary Empty => new();
}