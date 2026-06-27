using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Application.Abstractions;

public interface IShippingMethodRepository : IAggregateRepository<ShippingMethod>
{
    Task<List<ShippingMethod>> ListAvailableAsync(string countryCode, CancellationToken ct);
}