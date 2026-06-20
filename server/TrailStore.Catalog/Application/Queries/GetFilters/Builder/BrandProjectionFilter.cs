using TrailStore.Catalog.Application.Queries.GetFilters.Projections;

namespace TrailStore.Catalog.Application.Queries.GetFilters.Builder;

internal sealed record BrandProjectionFilter(string[] BrandSlugs) : IProjectionFilter
{
    public bool Filter(SkuProjection projection)
    {
        return BrandSlugs.Length == 0 || BrandSlugs.Contains(projection.Brand.Slug);
    }
}