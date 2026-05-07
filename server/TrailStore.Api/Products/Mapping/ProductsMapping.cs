using TrailStore.Api.Products.Dto;
using TrailStore.Domain.Enums;
using TrailStore.Domain.Products;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Products.Mapping;

public static class ProductsMapping
{
    public static ProductsFilter MapToFilter(this ProductsRequest request)
    {
        return new ProductsFilter
        {
            SortBy        = request.SortBy ?? SortBy.Manual,
            BrandSlugs    = request.Brand ?? [],
            CategorySlugs = request.Category ?? [],
            Pagination    = request.Pagination ?? false,
            Page          = request.Page ?? 0,
            PageSize      = request.PageSize ?? 30,
            PriceGte      = request.PriceGte ?? 0,
            PriceLte      = request.PriceLte ?? decimal.MaxValue,
            Availability  = request.Availability ?? Availability.All,
            Option        = request.Option?
                            .Select(kvp => new OptionSelection(kvp.Key, kvp.Value))
                            .ToArray() ?? []
        };
    }
}