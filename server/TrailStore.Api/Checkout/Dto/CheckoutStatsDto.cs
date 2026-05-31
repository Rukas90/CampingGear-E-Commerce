using TrailStore.Domain.Checkout.Enums;

namespace TrailStore.Api.Checkout.Dto;

public class CheckoutStatsDto
{
    public required CheckoutStatus Status { get; init; }
    
    public required decimal Subtotal { get; init; }
    public required decimal Total { get; init; }
    
    public decimal? Tax { get; init; }
    public decimal? ShippingCost { get; init; }
}