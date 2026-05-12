using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products.Specifications;

public static class ProductSpecifications
{
    public static Specification<Product> Id(Id<Product> id)
    {
        return Specification<Product>.Where(p => p.Id == id);
    }

    public static Specification<Product> Slug(string slug)
    {
        return Specification<Product>.Where(p => p.Slug == slug);
    }

    public static Specification<Product> Brand(string slug)
    {
        return Specification<Product>.Where(p => p.Brand.Slug == slug);
    }

    public static Specification<Product> Category(string slug)
    {
        return Specification<Product>.Where(p => p.Category.Slug == slug);
    }

    public static Specification<Product> PriceRange(decimal min, decimal max)
    {
        return Specification<Product>.Where(p => p.Skus.Any(s => s.UnitPrice >= min && s.UnitPrice <= max));
    }

    public static Specification<Product> InStock()
    {
        return Specification<Product>.Where(p => p.Skus.Any(s => s.Stock > 0));
    }

    public static Specification<Product> OutOfStock()
    {
        return Specification<Product>.Where(p => p.Skus.All(s => s.Stock <= 0));
    }

    public static Specification<Product> Options(OptionSelection[] options)
    {
        return options.GroupBy(filter => filter.GroupSlug).Aggregate(Specification<Product>.Blank,
            (specification, group)
                => specification.And(ByGroup(group.Key, group.Select(filter => filter.ValueSlug))));
    }

    private static Specification<Product> ByGroup(string groupSlug, IEnumerable<string> valueSlugs)
    {
        return Specification<Product>.Where(p => p.Skus.Any(sku =>
            sku.Options.Any(option =>
                option.OptionGroup.Slug == groupSlug &&
                valueSlugs.Contains(option.Slug))));
    }
}