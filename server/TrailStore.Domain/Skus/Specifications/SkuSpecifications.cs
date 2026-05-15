using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Skus.Specifications;

public static class SkuSpecifications
{
    public static Specification<Sku> Brand(string slug)
    {
        return Specification<Sku>.Where(sku => sku.Product.Brand.Slug == slug);
    }

    public static Specification<Sku> Category(string slug)
    {
        return Specification<Sku>.Where(sku => sku.Product.Category.Slug == slug);
    }

    public static Specification<Sku> PriceRange(decimal min, decimal max)
    {
        return Specification<Sku>.Where(p => p.Product.Skus.Any(s => s.UnitPrice >= min && s.UnitPrice <= max));
    }

    public static Specification<Sku> InStock()
    {
        return Specification<Sku>.Where(p => p.Product.Skus.Any(s => s.Stock > 0));
    }

    public static Specification<Sku> OutOfStock()
    {
        return Specification<Sku>.Where(p => p.Product.Skus.All(s => s.Stock <= 0));
    }
    
    public static Specification<Sku> Code(string code)
    {
        return Specification<Sku>.Where(sku => sku.Code == code);
    }
}