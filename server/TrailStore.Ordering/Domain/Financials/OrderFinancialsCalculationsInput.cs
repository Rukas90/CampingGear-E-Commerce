namespace TrailStore.Ordering.Domain.Financials;

public readonly record struct OrderFinancialsCalculationsInput
{
    public required LineFinancials[] Lines { get; init; }
    public required ShippingFinancials Shipping { get; init; }
}