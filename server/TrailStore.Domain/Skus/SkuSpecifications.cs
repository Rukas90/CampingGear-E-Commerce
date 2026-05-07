using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Skus;

public static class SkuSpecifications
{
    public static Specification<Sku> Brand(string slug)
        => Specification<Sku>.Where(sku => sku.Product.Brand.Slug == slug);
    
    public static Specification<Sku> Category(string slug)
        => Specification<Sku>.Where(sku => sku.Product.Category.Slug == slug);
    
    public static Specification<Sku> PriceRange(decimal min, decimal max)
        => Specification<Sku>.Where(p => p.Product.Skus.Any(s => s.UnitPrice >= min && s.UnitPrice <= max));
    
    public static Specification<Sku> InStock()
        => Specification<Sku>.Where(p => p.Product.Skus.Any(s => s.Stock > 0));

    public static Specification<Sku> OutOfStock()
        => Specification<Sku>.Where(p => p.Product.Skus.All(s => s.Stock <= 0));
}