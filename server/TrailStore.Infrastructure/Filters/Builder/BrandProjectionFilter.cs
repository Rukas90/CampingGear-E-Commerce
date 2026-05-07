using TrailStore.Infrastructure.Filters.Projections;

namespace TrailStore.Infrastructure.Filters.Builder;

internal sealed record BrandProjectionFilter(string[] BrandSlugs) : IProjectionFilter
{
    public bool Filter(SkuProjection projection)
    {
        return BrandSlugs.Length == 0 || BrandSlugs.Contains(projection.Brand.Slug);
    }
}