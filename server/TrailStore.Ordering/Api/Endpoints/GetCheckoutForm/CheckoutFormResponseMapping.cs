using TrailStore.Ordering.Api.Checkout;
using TrailStore.Ordering.Domain.Checkout;

namespace TrailStore.Ordering.Api.Endpoints.GetCheckoutForm;

public static class CheckoutFormResponseMapping
{
    public static CheckoutFormResponse ToResponse(this CheckoutForm form)
        => new()
        {
            Contact = form.Contact.ToResponse(),
            Shipping = form.Shipping.ToResponse(),
            Billing = form.Billing.ToResponse()
        };

    
}