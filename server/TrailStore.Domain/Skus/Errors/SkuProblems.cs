using TrailStore.Shared.Common;

namespace TrailStore.Domain.Skus.Errors;

public static class SkuProblems
{
    public static Problem InvalidSku
        => new("Invalid Item", "sku.invalid", ".");
    
    public static Problem InsufficientStock
        => new("Insufficient Stock", "sku.insufficient_stock", "Item or items no longer have sufficient stock.");
}