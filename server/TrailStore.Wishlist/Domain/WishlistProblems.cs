using TrailStore.Shared.Domain.Common;

namespace TrailStore.Wishlist.Domain;

public static class WishlistProblems
{
    public static readonly Problem NotFound 
        = new("Not found", "wishlist.not_found", "Wishlist not found.");
    
    public static readonly Problem ItemAlreadyAdded 
        = new("Item already added", "wishlist.item_already_added", "Item is already added to the wishlist.");
    
    public static readonly Problem ItemNotFound 
        = new("Item not found", "wishlist.item_not_found", "Item was not found in the wishlist.");
}