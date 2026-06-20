using TrailStore.Catalog.Application.Queries.GetFilters.Projections;

namespace TrailStore.Catalog.Application.Queries.GetFilters.Builder;

internal sealed record PriceProjectionFilter(decimal PriceGte, decimal PriceLte) : IProjectionFilter
{
    public bool Filter(SkuProjection projection)
    {
        return projection.UnitPrice >= PriceGte && projection.UnitPrice <= PriceLte;
    }
}