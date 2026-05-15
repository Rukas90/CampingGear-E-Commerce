using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Skus.Specifications;

public static class SkuSpecificationBuilder
{
    public static Specification<Sku> BuildFromCodes(params string[] codes)
    {
        return codes.Aggregate(
            Specification<Sku>.None,
            (spec, code) => spec.Or(SkuSpecifications.Code(code.ToUpper()))
        );
    }
}