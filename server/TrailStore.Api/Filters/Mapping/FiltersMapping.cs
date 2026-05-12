using TrailStore.Api.Filters.Dto;
using TrailStore.Domain.Filters.Models;
using TrailStore.Domain.Shared.Enums;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Filters.Mapping;

public static class FiltersExtensions
{
    public static FiltersQuery ToQuery(this FiltersRequest request)
    {
        return new FiltersQuery
        {
            QueryBrand = request.QueryBrand,
            QueryCategory = request.QueryCategory,
            FilterBrandSlugs = request.Brand ?? [],
            FilterCategorySlugs = request.Category ?? [],
            FilterPriceGte = request.PriceGte ?? 0,
            FilterPriceLte = request.PriceLte ?? decimal.MaxValue,
            FilterAvailability = request.Availability ?? Availability.All,
            FilterOption = request.Option?
                .Select(kvp => new OptionSelection(kvp.Key, kvp.Value))
                .ToArray() ?? []
        };
    }
}