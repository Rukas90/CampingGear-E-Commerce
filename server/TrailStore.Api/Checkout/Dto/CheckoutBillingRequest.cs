using TrailStore.Api.Common.Dto;

namespace TrailStore.Api.Checkout.Dto;

public class CheckoutBillingRequest
{
    public PostalAddressRequest? Address { get; init; }
    public bool? AsShippingAddress { get; init; }
    
}