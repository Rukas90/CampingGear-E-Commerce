namespace TrailStore.Ordering.Domain.Financials;

public readonly record struct ShippingFinancials(
    decimal CostBeforeTaxes,
    decimal TaxAmount,
    decimal CostAfterTaxes,
    decimal AddCostForFreeShipping,
    bool EligibleForFreeShipping);