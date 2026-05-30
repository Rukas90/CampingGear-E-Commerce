using TrailStore.Domain.Checkout.Enums;

namespace TrailStore.Api.Checkout.Dto;

public class CheckoutDto
{
    public required CheckoutStatus Status { get; init; }
}