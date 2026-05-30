using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Checkout.Models;

public class CheckoutForm
{
    public required CheckoutContact Contact { get; init; }
    public PostalAddress? ShippingAddress { get; init; }
    public required CheckoutBilling Billing { get; init; }
}