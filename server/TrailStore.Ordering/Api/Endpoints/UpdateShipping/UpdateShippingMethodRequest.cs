using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Api.Endpoints.UpdateShipping;

public sealed class UpdateShippingMethodRequest
{
    public Id<ShippingMethod> ShippingMethodId { get; init; }
}