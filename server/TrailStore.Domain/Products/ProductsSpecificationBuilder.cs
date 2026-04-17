using TrailStore.Domain.Enums;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products;

public static class ProductsSpecificationBuilder
{
    public static Specification<Product> Build(ProductsFilter filter)
    {
        var spec = Specification<Product>.Blank;

        if (filter.BrandSlug is not null)
        {
            spec = spec.And(ProductSpecifications.Brand(filter.BrandSlug));
        }
        
        if (filter.CategorySlug is not null)
        {
            spec = spec.And(ProductSpecifications.Category(filter.CategorySlug));
        }
        
        if (filter.PriceGte > 0 || filter.PriceLte < decimal.MaxValue)
        {
            spec = spec.And(ProductSpecifications.PriceRange(filter.PriceGte, filter.PriceLte));
        }
        
        if (filter.Option.Length > 0)
        {
            spec = spec.And(ProductSpecifications.Options(filter.Option));
        }
        
        spec = filter.Availability switch
        {
            Availability.InStock    => spec.And(ProductSpecifications.InStock()),
            Availability.OutOfStock => spec.And(ProductSpecifications.OutOfStock()),
            _                       => spec
        };

        return spec;
    }
}