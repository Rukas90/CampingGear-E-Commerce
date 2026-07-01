namespace TrailStore.Ordering.Domain.Financials;

public readonly record struct OrderFinancialsCalculationsInput
{
    public LineFinancials[] Lines { get; init; }
    public ShippingFinancials Shipping { get; init; }
}