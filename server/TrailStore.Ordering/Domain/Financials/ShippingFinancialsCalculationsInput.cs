namespace TrailStore.Ordering.Domain.Financials;

public readonly record struct ShippingFinancialsCalculationsInput
{
    public required LineFinancials[] Lines { get; init; }
    public required decimal TaxRate { get; init; }
    public required decimal ShippingFlatFee { get; init; }
    public required decimal FreeShippingThreshold { get; init; }
}