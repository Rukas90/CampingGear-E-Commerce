using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Api.Endpoints.GetCountryShippingMethods;

public class ShippingMethodResponse
{
    public required Id<ShippingMethod> Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal FlatFee { get; set; }
}