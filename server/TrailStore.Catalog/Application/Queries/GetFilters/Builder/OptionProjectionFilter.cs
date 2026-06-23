using TrailStore.Catalog.Application.Queries.GetFilters.Projections;
using TrailStore.Catalog.Domain.Options;

namespace TrailStore.Catalog.Application.Queries.GetFilters.Builder;

internal sealed record OptionProjectionFilter(OptionSelection Option) : IProjectionFilter
{
    public bool Filter(SkuProjection projection)
    {
        return projection.Options.Any(
            o => o.Group.Slug == Option.GroupSlug && o.Slug == Option.ValueSlug);
    }
} 