using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Application.Queries.GetFilters;

public static class FiltersSpecificationBuilder
{
    public static Specification<Sku> FromQuery(GetFiltersQuery query)
    {
        var spec = Specification<Sku>.All;

        if (query.QueryCategory is not null)
        {
            spec = spec.And(SkuSpecifications.Category(query.QueryCategory));
        }

        if (query.QueryBrand is not null)
        {
            spec = spec.And(SkuSpecifications.Brand(query.QueryBrand));
        }

        return spec;
    }
}