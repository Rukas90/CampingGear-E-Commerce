using TrailStore.Ordering.Api.Common.PostalAddress;

namespace TrailStore.Ordering.Api.Orders;

public sealed class OrderSummaryResponse
{
    public required string EmailAddress { get; init; }
    public required string Token { get; init; }
    public required FinancialsResponse Financials { get; init; }
    public required string ShippingName { get; init; }
    public required OrderLineItemSummaryResponse[] LineItems { get; init; }
    public required PostalAddressResponse Billing { get; init; }
}