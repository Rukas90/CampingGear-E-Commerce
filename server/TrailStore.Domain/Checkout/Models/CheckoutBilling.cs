using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Checkout.Models;

public class CheckoutBilling
{
    public bool AsShippingAddress { get; init; }
    public PostalAddress? Address { get; init; }
}