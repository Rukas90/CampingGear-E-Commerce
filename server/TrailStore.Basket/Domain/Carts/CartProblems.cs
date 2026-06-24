using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Carts;

public static class CartProblems
{
    public static readonly Problem ItemNotFound 
        = new("Item not found", "cart.item_not_found", "Item was not found.");
}