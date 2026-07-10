using TrailStore.Ordering.Api.Common.PostalAddress;

namespace TrailStore.Ordering.Api.Orders;

public sealed class OrderSummaryResponse
{
    public required string EmailAddress { get; init; }
    public required string Token { get; init; }
    public required decimal Subtotal { get; init; }
    public required decimal Tax { get; init; }
    public required decimal ShippingCost { get; init; }
    public required string ShippingName { get; init; }
    public required decimal Total { get; init; }
    public required OrderLineItemSummaryResponse[] LineItems { get; init; }
    public required PostalAddressResponse Billing { get; init; }
}