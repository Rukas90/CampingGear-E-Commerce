using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Results;

public sealed class ShippingMethodResult
{
    public required Id<ShippingMethod> Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal FlatFee { get; init; }
}