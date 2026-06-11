using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shipping.Interfaces;

public interface IShippingMethodRepository
{
    Task<List<ShippingMethod>> ListAvailableAsync(string countryCode, CancellationToken ct);
    
    Task<ShippingMethod?> FindByIdAsync(Id<ShippingMethod> id, CancellationToken ct);
}