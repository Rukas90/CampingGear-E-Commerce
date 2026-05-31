using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.Shared.Validators;

namespace TrailStore.Domain.Shared.Extensions;

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