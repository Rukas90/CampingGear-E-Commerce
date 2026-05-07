using TrailStore.Infrastructure.Filters.Projections;

namespace TrailStore.Infrastructure.Filters.Builder;

internal sealed record CategoryProjectionFilter(string[] CategorySlugs) : IProjectionFilter
{
    public bool Filter(SkuProjection projection)
    {
        return CategorySlugs.Length == 0 || CategorySlugs.Contains(projection.Category.Slug);
    }
}