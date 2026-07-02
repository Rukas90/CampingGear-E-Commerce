using TrailStore.Ordering.Domain.Orders;

namespace TrailStore.Ordering.Application.Results;

public class OrderSummary
{
    public required string Token { get; init; }
    public required decimal Subtotal { get; init; }
    public required decimal Tax { get; init; }
    public required decimal ShippingCost { get; init; }
    public required string ShippingName { get; init; }
    public required decimal Total { get; init; }
    public required OrderLineItem[] LineItems { get; init; }
}