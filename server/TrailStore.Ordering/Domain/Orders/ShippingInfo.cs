using TrailStore.Ordering.Domain.Financials;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public sealed class ShippingInfo
{
    public required Id<ShippingMethod> MethodId { get; init; }
    public required string Name { get; init; }
    public required string Code { get; init; }
    public required ShippingAddress Address { get; init; }
    public required ShippingFinancials Financials { get; init; }
}