namespace TrailStore.Ordering.Api.Orders;

public sealed class FinancialsResponse
{
    public required decimal Subtotal { get; init; }
    public decimal? Tax { get; init; }
    public decimal? ShippingCost { get; init; }
    public decimal? Total { get; init; }
}