namespace TrailStore.Ordering.Api.Orders;

public sealed class FreeShippingInfoResponse
{
    public decimal? AddCostForFreeShipping { get; init; }
    public bool EligibleForFreeShipping { get; init; }
}