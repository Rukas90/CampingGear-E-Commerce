using TrailStore.Ordering.Api.Orders;
using TrailStore.Ordering.Domain.Checkout;

namespace TrailStore.Ordering.Api.Endpoints.GetCheckoutStats;

public class CheckoutStatsResponse
{
    public required CheckoutStatus Status { get; init; }
    public required FinancialsResponse Financials { get; init; }
    public required FreeShippingInfoResponse FreeShippingInfo { get; init; }
}