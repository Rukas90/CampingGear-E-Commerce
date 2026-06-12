namespace TrailStore.Domain.Shared.Financials;

public readonly record struct Financials(
    decimal Subtotal,
    decimal Tax,
    decimal ShippingCost,
    decimal Total,
    decimal AddCostForFreeShipping,
    bool EligibleForFreeShipping);