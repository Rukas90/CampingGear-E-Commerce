using TrailStore.Catalog.Application.Queries.GetFilters.Projections;
using TrailStore.Catalog.Domain.Products;

namespace TrailStore.Catalog.Application.Queries.GetFilters.Builder;

internal sealed record AvailabilityProjectionFilter(Availability Availability) : IProjectionFilter
{
    public bool Filter(SkuProjection projection)
    {
        return Availability switch
        {
            Availability.InStock => projection.Stock > 0,
            Availability.OutOfStock => projection.Stock <= 0,
            _ => true
        };
    }
}