using TrailStore.Catalog.Application.Abstractions;
using TrailStore.Catalog.Domain.Filters;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Infrastructure.Products;

[AppService<IProductsQueryBuilder>]
public class ProductsQueryBuilder : IProductsQueryBuilder
{
    public ProductsQuery Build(ProductsFilter filter)
    {
        var spec = BuildSpecification(filter);

        return new ProductsQuery
        {
            Specification = spec,
            SortBy = filter.SortBy,
            Pagination = filter.Pagination,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    private static Specification<Product> BuildSpecification(ProductsFilter filter)
    {
        var spec = Specification<Product>.All;

        if (filter.Brands.Length > 0)
        {
            var brandSpec = filter.Brands
                .Skip(1)
                .Aggregate(
                    ProductSpecifications.Brand(Slug.Create(filter.Brands[0])),
                    (specification, slug) => specification.Or(ProductSpecifications.Brand(Slug.Create(slug)))
                );

            spec = spec.And(brandSpec);
        }

        if (filter.Categories.Length > 0)
        {
            var categorySpec = filter.Categories
                .Skip(1)
                .Aggregate(
                    ProductSpecifications.Category(Slug.Create(filter.Categories[0])),
                    (specification, slug) => specification.Or(ProductSpecifications.Category(Slug.Create(slug)))
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
                    ProductSpecifications.SkuCode(SkuCode.Create(filter.SkuCode[0])),
                    (specification, code) => specification.Or(ProductSpecifications.SkuCode(SkuCode.Create(code)))
                );
            
            spec = spec.And(codeSpec);
        }

        return spec;
    }
}