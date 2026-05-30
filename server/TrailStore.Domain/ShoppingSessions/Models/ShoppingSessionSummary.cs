using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.ShoppingSessions.Models;

public record ShoppingSessionSummary(
    Id<ShoppingSession>? Id,
    int CartCount,
    int WishlistCount)
{
    public static ShoppingSessionSummary Blank 
        => new(null, 0, 0);
};