namespace TrailStore.Ordering.Domain.Financials;

public readonly record struct LineFinancialsCalculationInput
{
    public required decimal UnitPrice { get; init; }
    public required decimal TaxRate { get; init; }
    public required int Quantity { get; init; }
}