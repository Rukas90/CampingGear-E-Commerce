using TrailStore.Ordering.Api.Common.PostalAddress;
using TrailStore.Ordering.Domain.Checkout;

namespace TrailStore.Ordering.Api.Checkouts;

public static class CheckoutResponseMapping
{
    public static CheckoutContactResponse ToResponse(this CheckoutContact contact)
        => new()
        {
            EmailAddress = contact.EmailAddress,
            IsEmailReadOnly = contact.IsEmailReadOnly
        };
    
    public static CheckoutShippingResponse ToResponse(this CheckoutShipping shipping)
        => new()
        {
            Address = shipping.Address?.ToResponse(),
            SelectedMethodId = shipping.SelectedMethodId ?? Guid.Empty
        };
    
    public static CheckoutBillingResponse ToResponse(this CheckoutBilling billing)
        => new()
        {
            AsShippingAddress = billing.AsShippingAddress,
            Address = billing.Address?.ToResponse()
        };
}