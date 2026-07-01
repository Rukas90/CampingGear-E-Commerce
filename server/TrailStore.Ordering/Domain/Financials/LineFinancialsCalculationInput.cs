namespace TrailStore.Ordering.Domain.Financials;

public readonly record struct LineFinancialsCalculationInput
{
    public decimal UnitPrice { get; init; }
    public decimal TaxRate { get; init; }
    public int Quantity { get; init; }
}