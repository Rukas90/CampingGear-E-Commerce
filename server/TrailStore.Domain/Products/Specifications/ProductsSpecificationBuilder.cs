using TrailStore.Domain.Products.Models;
using TrailStore.Domain.Shared.Enums;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products.Specifications;

public static class ProductsSpecificationBuilder
{
    public static Specification<Product> Build(ProductsFilter filter)
    {
        var spec = Specification<Product>.All;

        if (filter.BrandSlugs.Length > 0)
        {
            var brandSpec = filter.BrandSlugs
                .Skip(1)
                .Aggregate(
                    ProductSpecifications.Brand(filter.BrandSlugs[0]),
                    (specification, slug) => specification.Or(ProductSpecifications.Brand(slug))
                );

            spec = spec.And(brandSpec);
        }

        if (filter.CategorySlugs.Length > 0)
        {
            var categorySpec = filter.CategorySlugs
                .Skip(1)
                .Aggregate(
                    ProductSpecifications.Category(filter.CategorySlugs[0]),
                    (specification, slug) => specification.Or(ProductSpecifications.Category(slug))
                );
            spec = spec.And(categorySpec);
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
            Availability.InStock => spec.And(ProductSpecifications.InStock()),
            Availability.OutOfStock => spec.And(ProductSpecifications.OutOfStock()),
            _ => spec
        };
        
        if (filter.SkuCode.Length > 0)
        {
            var codeSpec = filter.SkuCode
                .Skip(1)
                .Aggregate(
                    ProductSpecifications.SkuCode(filter.SkuCode[0].ToUpper()),
                    (specification, code) => specification.Or(ProductSpecifications.SkuCode(code.ToUpper()))
                );
            
            spec = spec.And(codeSpec);
        }

        return spec;
    }
}