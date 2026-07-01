namespace TrailStore.Ordering.Domain.Financials;

public readonly record struct LineFinancials
{
    public decimal PriceBeforeTax { get; init; }
    public decimal TaxRate { get; init; }
    public decimal TaxAmount { get; init; }
    public decimal PriceAfterTax { get; init; }
}