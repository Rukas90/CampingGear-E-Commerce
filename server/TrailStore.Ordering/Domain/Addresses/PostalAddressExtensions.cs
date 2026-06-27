using TrailStore.Ordering.Domain.Shipping;

namespace TrailStore.Ordering.Domain.Addresses;

public static class PostalAddressExtensions
{
    extension(PostalAddress? postalAddress)
    {
        public bool IsValid()
        {
            return postalAddress is not null 
                   && AddressValidator.Validate(postalAddress).IsValid;
        }
    }
}