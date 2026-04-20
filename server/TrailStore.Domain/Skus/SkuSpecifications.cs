using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Skus;

public static class SkuSpecifications
{
    public static Specification<Sku> Brand(string slug)
        => Specification<Sku>.Where(sku => sku.Product.Brand.Slug == slug);
    
    public static Specification<Sku> Category(string slug)
        => Specification<Sku>.Where(sku => sku.Product.Category.Slug == slug);
}