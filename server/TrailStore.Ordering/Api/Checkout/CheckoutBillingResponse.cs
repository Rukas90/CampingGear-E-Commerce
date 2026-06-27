using TrailStore.Ordering.Api.Common.PostalAddress;

namespace TrailStore.Ordering.Api.Checkout;

public class CheckoutBillingResponse
{
    public required PostalAddressResponse? Address { get; init; }
    public bool AsShippingAddress { get; init; }
}