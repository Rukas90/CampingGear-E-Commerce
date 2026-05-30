using TrailStore.Api.Common.Dto;

namespace TrailStore.Api.Checkout.Dto;

public class CheckoutFormDto
{
    public required CheckoutContactDto Contact { get; init; }
    public PostalAddressDto? ShippingAddress { get; init; }
    public required CheckoutBillingDto Billing { get; init; }
}