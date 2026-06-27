using TrailStore.Ordering.Api.Checkout;

namespace TrailStore.Ordering.Api.Endpoints.GetCheckoutForm;

public class CheckoutFormResponse
{
    public required CheckoutContactResponse Contact { get; init; }
    public CheckoutShippingResponse? Shipping { get; init; }
    public required CheckoutBillingResponse Billing { get; init; }
}