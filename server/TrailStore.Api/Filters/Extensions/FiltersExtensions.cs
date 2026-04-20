using TrailStore.Api.Filters.Dto;
using TrailStore.Domain.Models;
using TrailStore.Domain.Skus;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Filters.Extensions;

public static class FiltersExtensions
{
    public static Specification<Sku> ToSpecification(this FiltersRequest request)
    {
        var spec = Specification<Sku>.Blank;

        if (request.Category is not null)
        {
            spec = spec.And(SkuSpecifications.Category(request.Category));
        }

        if (request.Brand is not null)
        {
            spec = spec.And(SkuSpecifications.Brand(request.Brand));
        }

        return spec;
    }
}