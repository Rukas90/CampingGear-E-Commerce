using TrailStore.Domain.Models;
using TrailStore.Domain.Skus;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Filters;

public static class FiltersSpecificationBuilder
{
    public static Specification<Sku> FromQuery(FiltersQuery query)
    {
        var spec = Specification<Sku>.Blank;

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