using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Models;
using TrailStore.Domain.Orders.Models;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Api.Checkout.Mapping;

public static class RequestMapping
{
    public static CheckoutContact ToContact(this UpdateContactRequest request)
        => new()
        {
            EmailAddress = request.EmailAddress
        };
    
    public static CheckoutBilling ToBilling(this UpdateBillingRequest request)
        => new()
        {
            Address = request.Address is not null 
                ? new BillingAddress(request.Address.ToPostalAddress()) 
                : new BillingAddress(PostalAddress.Empty),
            AsShippingAddress = request.AsShippingAddress ?? false
        };
}