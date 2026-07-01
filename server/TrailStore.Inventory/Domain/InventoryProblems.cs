using TrailStore.Shared.Domain.Common;

namespace TrailStore.Inventory.Domain;

public static class InventoryProblems
{
    public static Problem SkuNotFound(Guid skuId)
        => new("Sku not found", "inventory.sku_not_found", $"Inventory item by sku id {skuId} is not found.");
    
    public static Problem InsufficientStock(Guid skuId, int requested, int available)
        => new("Insufficient stock", "inventory.insufficient_stock", 
            $"Requested {requested} units for SKU {skuId} but only {available} available.");

    public static Problem InvalidQuantity(int quantity)
        => new("Invalid quantity", "inventory.invalid_quantity", 
            $"Quantity must be greater than zero, got {quantity}.");
}