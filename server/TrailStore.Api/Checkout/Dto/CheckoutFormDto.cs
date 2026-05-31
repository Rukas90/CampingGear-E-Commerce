namespace TrailStore.Api.Checkout.Dto;

public class CheckoutFormDto
{
    public required CheckoutContactDto Contact { get; init; }
    public CheckoutShippingDto? Shipping { get; init; }
    public required CheckoutBillingDto Billing { get; init; }
}