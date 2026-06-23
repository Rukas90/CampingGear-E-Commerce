using TrailStore.Catalog.Domain.Filters;
using TrailStore.Catalog.Domain.Options;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Application.Queries.GetProducts;

public static class QueryToFilterMapping
{
    public static ProductsFilter ToFilter(this GetProductsQuery query)
        => new()
        {
            SortBy = query.SortBy ?? ProductsSortBy.Manual,
            Availability = query.Availability ?? Availability.All,
            Brands = query.Brand ?? [],
            Categories = query.Category ?? [],
            Option = query.Option?
                .Select(kvp => new OptionSelection(Slug.Create(kvp.Key), Slug.Create(kvp.Value)))
                .ToArray() ?? [],
            Pagination = query.Pagination ?? true,
            Page = query.Page ?? 0,
            PageSize = query.PageSize ?? 10,
            PriceGte = query.PriceGte ?? 0,
            PriceLte = query.PriceLte ?? decimal.MaxValue,
            SkuCode = query.SkuCode ?? []
        };
}