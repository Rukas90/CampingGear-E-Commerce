using TrailStore.Infrastructure.Filters.Projections;

namespace TrailStore.Infrastructure.Filters.Builder;

internal sealed record PriceProjectionFilter(decimal PriceGte, decimal PriceLte) : IProjectionFilter
{
    public bool Filter(SkuProjection projection)
    {
        return projection.UnitPrice >= PriceGte && projection.UnitPrice <= PriceLte;
    }
}