using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Countries.Models;
using TrailStore.Ordering.Domain.Financials;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public sealed class CreateOrderRequest
{
    public Id<UserRef>? UserId { get; init; }
    public required string EmailAddress { get; init; }
    public required BillingAddress BillingAddress { get; init; }
    public required Country Country { get; init; }
    public required OrderLineItem[] Items { get; init; }
    public required ShippingInfo ShippingInfo { get; init; }
    public required OrderFinancials Financials { get; init; }
    public required string CurrencyCode { get; init; }
}