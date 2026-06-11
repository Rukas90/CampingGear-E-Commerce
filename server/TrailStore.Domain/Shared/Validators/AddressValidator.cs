using TrailStore.Domain.Countries.Data;
using TrailStore.Domain.Countries.Enums;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Validation;

namespace TrailStore.Domain.Shared.Validators;

// ReSharper disable UnusedMethodReturnValue.Global

public static class AddressValidator
{
    public static ValidationState Validate(PostalAddress? address, ValidationState? state = null, ValidationScope? scope = null)
    {
        state ??= ValidationState.Ok(scope);
        
        if (address is null || string.IsNullOrWhiteSpace(address.RecipientFirstName))
        {
            state.FailedWith(ValidationFailure.New(nameof(address.RecipientFirstName), "First name is required."));
        }
        
        if (address is null || string.IsNullOrWhiteSpace(address.RecipientLastName))
        {
            state.FailedWith(ValidationFailure.New(nameof(address.RecipientLastName), "Last name is required."));
        }
        
        if (address is null || string.IsNullOrWhiteSpace(address.AddressLine))
        {
            state.FailedWith(ValidationFailure.New(nameof(address.AddressLine), "Address line is required."));
        }
        
        if (address is null || string.IsNullOrWhiteSpace(address.City))
        {
            state.FailedWith(ValidationFailure.New(nameof(address.City), "City is required."));
        }
        
        var country = address is not null ? CountryRegistry.For(address.CountryCode) : null;

        if (country is null)
        {
            state.FailedWith(ValidationFailure.New(nameof(address.CountryCode), "Unsupported country."));
        }
        else
        {
            if (address is null ||country.PostalCode is PostalCodeRequirement.Required
                && string.IsNullOrWhiteSpace(address.PostalCode))
            {
                state.FailedWith(ValidationFailure.New(nameof(address.PostalCode), $"{country.PostalCodeLabel} is required."));
            }
        
            if (address is null || country.HasRegion
                && string.IsNullOrWhiteSpace(address.Region))
            {
                state.FailedWith(ValidationFailure.New(nameof(address.Region), $"{country.RegionLabel} is required."));
            }
        }

        PhoneNumberValidator.Validate(address?.PhoneNumber, address?.CountryCode, state, scope);

        return state;
    }
}