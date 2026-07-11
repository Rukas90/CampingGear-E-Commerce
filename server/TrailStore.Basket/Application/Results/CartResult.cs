using TrailStore.Basket.Domain.Carts;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Results;

public sealed record CartResult(
    Id<Cart>? Id, List<CartItemResult> Items)
{
    public bool IsEmpty => Items.Count == 0;
    
    public static CartResult Empty
        => new(Id: null, []);
};