using TrailStore.Catalog.Application.Queries.GetFilters.Projections;

namespace TrailStore.Catalog.Application.Queries.GetFilters.Builder;

internal sealed record CategoryProjectionFilter(string[] CategorySlugs) : IProjectionFilter
{
    public bool Filter(SkuProjection projection)
    {
        return CategorySlugs.Length == 0 || CategorySlugs.Contains(projection.Category.Slug);
    }
}