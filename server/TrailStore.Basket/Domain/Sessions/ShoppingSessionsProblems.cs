using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Sessions;

public static class ShoppingSessionsProblems
{
    public static readonly Problem SessionNotFound
        = new("Not Found", "shopping.session.not_found", "Shopping session was not found.");
    
    public static readonly Problem SessionExpired
        = new("Expired", "shopping.session.expired", "Shopping session is expired.");
    
    public static readonly Problem MergeWithSelf
        = new("Merge with Self", "shopping.session.merge_with_self", "Shopping session cannot be merged with self.");
    
    public static readonly Problem MergeWithUserSession
        = new("Merge with user session", "shopping.session.merge_with_user", "Shopping session cannot be merged with another user session.");
    
    public static readonly Problem MergeWithAnonymous
        = new("Merge with anonymous", "shopping.session.merge_with_anonymous", "Cannot merge user session with anonymous user session.");
}