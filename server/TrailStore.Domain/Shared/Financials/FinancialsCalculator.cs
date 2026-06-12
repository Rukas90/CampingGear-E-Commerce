namespace TrailStore.Domain.Shared.Financials;

public static class FinancialsCalculator
{
    public static Financials Calculate(FinancialsCalculationsInput input)
    {
        var subtotal = input.Subtotal;
        var tax = subtotal * input.TaxRate;

        var eligibleForFreeShipping = subtotal >= input.FreeShippingThreshold;
        var shippingCost = eligibleForFreeShipping
                ? 0m
                : input.ShippingFlatFee;
        
        var total = subtotal + tax + shippingCost;

        return new Financials(
            Subtotal: subtotal,
            Tax: tax,
            ShippingCost: shippingCost,
            Total: total,
            AddCostForFreeShipping: eligibleForFreeShipping ? 0m : input.FreeShippingThreshold - subtotal,
            EligibleForFreeShipping: eligibleForFreeShipping
        );
    }
}