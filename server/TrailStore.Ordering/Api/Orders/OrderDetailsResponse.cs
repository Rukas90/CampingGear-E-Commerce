using TrailStore.Ordering.Api.Common.PostalAddress;
using TrailStore.Ordering.Domain.Orders;

namespace TrailStore.Ordering.Api.Orders;

public sealed class OrderDetailsResponse
{
    public required string EmailAddress { get; init; }
    public required string Token { get; init; }
    public required FinancialsResponse Financials { get; init; }
    public required string ShippingName { get; init; }
    public required OrderStatus Status { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required OrderLineItemSummaryResponse[] LineItems { get; init; }
    public required PostalAddressResponse Billing { get; init; }
}