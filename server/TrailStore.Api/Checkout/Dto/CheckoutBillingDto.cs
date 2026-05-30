using TrailStore.Api.Common.Dto;

namespace TrailStore.Api.Checkout.Dto;

public class CheckoutBillingDto
{
    public required PostalAddressDto? Address { get; init; }
    public bool AsShippingAddress { get; init; }
}