using TrailStore.Catalog.Application.Queries.GetFilters.Projections;

namespace TrailStore.Catalog.Application.Queries.GetFilters.Builder;

internal interface IProjectionFilter
{
    bool Filter(SkuProjection projection);
}