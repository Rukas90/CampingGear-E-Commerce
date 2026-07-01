namespace TrailStore.Ordering.Domain.Financials;

public readonly record struct ShippingFinancialsCalculationsInput
{
    public LineFinancials[] Lines { get; init; }
    public decimal TaxRate { get; init; }
    public decimal ShippingFlatFee { get; init; }
    public decimal FreeShippingThreshold { get; init; }
}