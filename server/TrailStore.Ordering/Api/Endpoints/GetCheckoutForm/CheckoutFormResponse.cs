using TrailStore.Ordering.Api.Checkouts;

namespace TrailStore.Ordering.Api.Endpoints.GetCheckoutForm;

public sealed class CheckoutFormResponse
{
    public required CheckoutContactResponse Contact { get; init; }
    public CheckoutShippingResponse? Shipping { get; init; }
    public required CheckoutBillingResponse Billing { get; init; }
}