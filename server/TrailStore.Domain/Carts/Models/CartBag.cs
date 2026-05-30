using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Carts.Models;

public record CartBag<TItem>(Id<ShoppingSession>? SessionId, List<TItem> Items)
{
    public bool IsEmpty => Items.Count == 0;
    
    public static CartBag<TItem> Empty
        => new(null, []);
};