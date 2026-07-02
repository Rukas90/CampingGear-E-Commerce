using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Products;

public class ProductProblems
{
    public static Problem NotFoundBySlug(string slug)
        => new("Not Found", "product.not_found", $"Product was not found by slug '{slug}'");
    
    public static Problem SkuNotFound(string productName, Id<Sku> skuId)
        => new("Sku not found", "product.sku_not_found", $"Product {productName} sku by id {skuId} was not found");
    
    public static Problem InvalidSkuStock(int newStock)
        => new("Invalid stock", "product.invalid_sku_stock", $"Trying to set a new sku stock {newStock} that is invalid");
}