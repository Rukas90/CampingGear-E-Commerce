using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Sessions;

public record ShoppingSessionSummary(Id<ShoppingSession>? Id, int CartCount, int WishlistCount)
{
    public static ShoppingSessionSummary Blank 
        => new(null, 0, 0);
};