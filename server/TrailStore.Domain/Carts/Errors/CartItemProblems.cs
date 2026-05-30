using TrailStore.Shared.Common;

namespace TrailStore.Domain.Carts.Errors;

public static class CartItemProblems
{
    public static readonly Problem SkuNotFound
        = new("Not Found", "cart.item.sku_not_found", "SKU by code was not found.");

    public static readonly Problem ItemNotFound
        = new("Not Found", "cart.item_not_found", "Cart item was not found.");
    
    public static readonly Problem InvalidQuantity
        = new("Invalid Quantity", "cart.item.invalid_quantity", "Quantity must be greater than zero.");

    public static readonly Problem InsufficientStock
        = new("Insufficient Stock", "cart.item.insufficient_stock", "Requested quantity exceeds available stock.");

    public static readonly Problem OutOfStock
        = new("Out Of Stock", "cart.item.out_of_stock", "This item is currently out of stock.");
}