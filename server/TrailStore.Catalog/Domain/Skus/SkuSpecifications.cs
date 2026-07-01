using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Skus;

public static class SkuSpecifications
{
    public static Specification<Sku> Id(Id<Sku> id)
    {
        return Specification<Sku>.Where(sku => sku.Product.Skus.Any(s => s.Id == id));
    }
    
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
    
    public static Specification<Sku> Code(SkuCode code)
    {
        return Specification<Sku>.Where(sku => sku.Code == code);
    }
}