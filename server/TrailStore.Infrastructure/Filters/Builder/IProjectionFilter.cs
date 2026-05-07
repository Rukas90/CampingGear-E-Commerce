using TrailStore.Infrastructure.Filters.Projections;

namespace TrailStore.Infrastructure.Filters.Builder;

internal interface IProjectionFilter
{
    bool Filter(SkuProjection projection);
}