using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Sessions;

public static class ShoppingSessionsProblems
{
    public static readonly Problem SessionNotFound
        = new("Not Found", "shopping.session.not_found", "Shopping session was not found.");
    
    public static readonly Problem SessionExpired
        = new("Expired", "shopping.session.expired", "Shopping session is expired.");
}