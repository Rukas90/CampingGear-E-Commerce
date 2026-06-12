using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Models;

namespace TrailStore.Api.Checkout.Mapping;

public static class CheckoutMapping
{
    public static CheckoutStatsDto ToDto(this CheckoutStats stats)
        => new()
        {
            Status = stats.Status,
            Subtotal = stats.Subtotal,
            Tax = stats.Tax,
            Total = stats.Total,
            ShippingCost = stats.ShippingCost,
            AddCostForFreeShipping = stats.AddCostForFreeShipping,
            EligibleForFreeShipping = stats.EligibleForFreeShipping
        };

    public static CheckoutFormDto ToDto(this CheckoutForm form)
        => new()
        {
            Contact = form.Contact.ToDto(),
            Shipping = form.Shipping.ToDto(),
            Billing = form.Billing.ToDto()
        };

    public static CheckoutContactDto ToDto(this CheckoutContact contact)
        => new()
        {
            EmailAddress = contact.EmailAddress
        };

    public static CheckoutShippingDto ToDto(this CheckoutShipping shipping)
        => new()
        {
            Address = shipping.Address?.ToDto(),
            SelectedMethodId = shipping.SelectedMethodId
        };
    
    public static CheckoutBillingDto ToDto(this CheckoutBilling billing)
        => new()
        {
            Address = billing.Address?.ToDto(),
            AsShippingAddress = billing.AsShippingAddress
        };
}