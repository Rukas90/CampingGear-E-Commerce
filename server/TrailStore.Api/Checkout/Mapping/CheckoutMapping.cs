using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Models;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Api.Checkout.Mapping;

public static class CheckoutMapping
{
    public static CheckoutDto ToDto(this CheckoutSession session)
        => new()
        {
            Status = session.Status
        };

    public static CheckoutFormDto ToDto(this CheckoutForm form)
        => new()
        {
            Contact = form.Contact.ToDto(),
            ShippingAddress = form.ShippingAddress?.ToDto(),
            Billing = form.Billing.ToDto()
        };

    public static CheckoutContactDto ToDto(this CheckoutContact contact)
        => new()
        {
            EmailAddress = contact.EmailAddress
        };
    
    public static CheckoutBillingDto ToDto(this CheckoutBilling billing)
        => new()
        {
            Address = billing.Address?.ToDto(),
            AsShippingAddress = billing.AsShippingAddress
        };
}