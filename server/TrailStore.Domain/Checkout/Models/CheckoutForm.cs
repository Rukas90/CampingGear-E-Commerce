namespace TrailStore.Domain.Checkout.Models;

public class CheckoutForm
{
    public required CheckoutContact Contact { get; init; }
    public required CheckoutShipping Shipping { get; init; }
    public required CheckoutBilling Billing { get; init; }
}