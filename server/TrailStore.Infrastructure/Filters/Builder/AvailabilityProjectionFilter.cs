using TrailStore.Domain.Enums;
using TrailStore.Infrastructure.Filters.Projections;

namespace TrailStore.Infrastructure.Filters.Builder;

internal sealed record AvailabilityProjectionFilter(Availability Availability) : IProjectionFilter
{
    public bool Filter(SkuProjection projection)
    {
        return Availability switch
        {
            Availability.InStock    => projection.Stock > 0,
            Availability.OutOfStock => projection.Stock <= 0,
            _                       => true
        };
    }
}