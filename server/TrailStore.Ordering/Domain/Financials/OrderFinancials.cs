namespace TrailStore.Ordering.Domain.Financials;

public readonly record struct OrderFinancials(
    decimal Subtotal,
    decimal TaxAmount,
    decimal TotalPrice);