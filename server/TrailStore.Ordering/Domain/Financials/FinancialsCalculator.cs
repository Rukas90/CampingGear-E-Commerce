namespace TrailStore.Ordering.Domain.Financials;

public static class FinancialsCalculator
{
    public static OrderFinancials CalculateOrder(OrderFinancialsCalculationsInput input)
    {
        var subtotal = input.Lines.Sum(line => line.PriceBeforeTax) 
                       + input.Shipping.CostBeforeTaxes;
    
        var taxAmount = input.Lines.Sum(line => line.TaxAmount) 
                        + input.Shipping.TaxAmount;
    
        var total = subtotal + taxAmount;

        return new OrderFinancials(subtotal, taxAmount, total);
    }

    public static ShippingFinancials CalculateShipping(ShippingFinancialsCalculationsInput input)
    {
        var subtotal = input.Lines.Sum(line => line.PriceBeforeTax);
        var eligibleForFreeShipping = subtotal >= input.FreeShippingThreshold;
        var shippingCost = eligibleForFreeShipping
            ? 0m
            : input.ShippingFlatFee;
        var taxAmount = shippingCost * input.TaxRate;

        return new ShippingFinancials
        {
            CostBeforeTaxes = shippingCost,
            TaxAmount = taxAmount,
            CostAfterTaxes = shippingCost + taxAmount,
            AddCostForFreeShipping = eligibleForFreeShipping 
                ? 0m : input.FreeShippingThreshold - subtotal,
            EligibleForFreeShipping = eligibleForFreeShipping
        };
    }

    public static LineFinancials CalculateLine(LineFinancialsCalculationInput input)
    {
        var subtotal = input.UnitPrice * input.Quantity;
        var taxAmount = subtotal * input.TaxRate;
        var total = subtotal + taxAmount;

        return new LineFinancials
        {
            PriceBeforeTax = subtotal,
            TaxAmount = taxAmount,
            TaxRate = input.TaxRate,
            PriceAfterTax = total
        };
    }
}