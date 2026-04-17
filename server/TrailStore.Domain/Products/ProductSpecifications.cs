using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products;

public class ProductSpecifications
{
    public static Specification<Product> Id(Id<Product> id)
        => Specification<Product>.Where(p => p.Id == id);
    
    public static Specification<Product> Brand(string slug)
        => Specification<Product>.Where(p => p.Brand.Slug == slug);

    public static Specification<Product> Category(string slug)
        => Specification<Product>.Where(p => p.Category.Slug == slug);

    public static Specification<Product> PriceRange(decimal min, decimal max)
        => Specification<Product>.Where(p => p.Skus.Any(s => s.UnitPrice >= min && s.UnitPrice <= max));

    public static Specification<Product> InStock()
        => Specification<Product>.Where(p => p.Skus.Any(s => s.Stock > 0));

    public static Specification<Product> OutOfStock()
        => Specification<Product>.Where(p => p.Skus.All(s => s.Stock <= 0));

    public static Specification<Product> Options(OptionFilter[] options)
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