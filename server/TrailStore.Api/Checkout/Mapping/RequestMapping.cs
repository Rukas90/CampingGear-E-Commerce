using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Models;

namespace TrailStore.Api.Checkout.Mapping;

public static class RequestMapping
{
    public static CheckoutContact ToContact(this CheckoutContactRequest request)
        => new()
        {
            EmailAddress = request.EmailAddress
        };
    
    public static CheckoutBilling ToBilling(this CheckoutBillingRequest request)
        => new()
        {
            Address = request.Address?.ToPostalAddress(),
            AsShippingAddress = request.AsShippingAddress ?? false
        };
}