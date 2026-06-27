using TrailStore.Ordering.Domain.Checkout;

namespace TrailStore.Ordering.Api.Endpoints.GetCheckoutStats;

public static class CheckoutStatsResponseMapping
{
    public static CheckoutStatsResponse ToResponse(this CheckoutStats stats)
        => new()
        {
            Status = stats.Status,
            Subtotal = stats.Subtotal,
            Total = stats.Total,
            Tax = stats.Tax,
            ShippingCost = stats.ShippingCost,
            AddCostForFreeShipping = stats.AddCostForFreeShipping,
            EligibleForFreeShipping = stats.EligibleForFreeShipping,
        };
}