namespace TrailStore.Ordering.Api.Endpoints.GetOrder;

public sealed class OrderSummaryResponse
{
    public required decimal Subtotal { get; init; }
    public required decimal Tax { get; init; }
    public required decimal ShippingCost { get; init; }
    public required string ShippingName { get; init; }
    public required decimal Total { get; init; }
    public required OrderLineItemSummaryResponse[] LineItems { get; init; }
}