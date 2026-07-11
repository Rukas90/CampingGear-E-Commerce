using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Carts;

public static class CartProblems
{
    public static readonly Problem ItemNotFound 
        = new("Item not found", "cart.item_not_found", "Item was not found.");

    public static Problem UnexpectedProblem(string message)
        => new Problem("Unexpected problem", "cart.unexpected_problem", message);
    
    public static readonly Problem NotFound
        = new("Not Found", "cart.not_found", "Cart was not found.");
    
    public static readonly Problem Expired
        = new("Expired", "cart.expired", "Cart is expired.");
    
    public static readonly Problem MergeWithSelf
        = new("Merge with Self", "cart.merge_with_self", "Cart cannot be merged with itself.");
    
    public static readonly Problem MergeWithUserCart
        = new("Merge with user cart", "cart.merge_with_user", "Cart cannot be merged with another user cart.");
    
    public static readonly Problem MergeUserToAnonymous
        = new("Merge with anonymous", "cart.merge_with_anonymous", "Cannot merge user cart to an anonymous user cart.");
}