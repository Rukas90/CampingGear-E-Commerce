using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Shipping.Interfaces;

public interface IShippingMethodRepository
{
    Task<List<ShippingMethod>> ListAvailableAsync(string countryCode, CancellationToken ct);
}