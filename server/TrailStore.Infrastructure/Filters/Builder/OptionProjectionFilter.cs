using TrailStore.Infrastructure.Filters.Projections;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Filters.Builder;

internal sealed record OptionProjectionFilter(OptionSelection Option) : IProjectionFilter
{
    public bool Filter(SkuProjection projection)
    {
        return projection.Options.Any(o => o.Group.Slug == Option.GroupSlug && o.Slug == Option.ValueSlug);
    }
}