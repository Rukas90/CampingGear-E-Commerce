namespace TrailStore.Domain.Shared.Financials;

public readonly record struct FinancialsCalculationsInput
{
    public decimal Subtotal { get; init; }
    public decimal TaxRate { get; init; }
    public decimal ShippingFlatFee { get; init; }
    public decimal FreeShippingThreshold { get; init; }
}