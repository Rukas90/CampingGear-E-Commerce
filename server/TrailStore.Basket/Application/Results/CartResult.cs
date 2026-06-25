using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Results;

public sealed record CartResult(
    Id<ShoppingSession>? SessionId, List<CartItemResult> Items)
{
    public bool IsEmpty => Items.Count == 0;
    
    public static CartResult Empty
        => new(SessionId: null, []);
};