using TrailStore.Domain.Countries.Data;
using TrailStore.Domain.Countries.Enums;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Validation;

namespace TrailStore.Domain.Shared.Validators;

// ReSharper disable UnusedMethodReturnValue.Global

public static class AddressValidator
{
    public static ValidationState Validate(PostalAddress address, ValidationState? state = null, string? prefix = null)
    {
        state ??= ValidationState.Ok();
        
        if (string.IsNullOrWhiteSpace(address.RecipientFirstName))
        {
            state.FailedWith(ValidationFailure.New(Field(nameof(address.RecipientFirstName)), "First name is required."));
        }
        
        if (string.IsNullOrWhiteSpace(address.RecipientLastName))
        {
            state.FailedWith(ValidationFailure.New(Field(nameof(address.RecipientLastName)), "Last name is required."));
        }
        
        if (string.IsNullOrWhiteSpace(address.AddressLine))
        {
            state.FailedWith(ValidationFailure.New(Field(nameof(address.AddressLine)), "Address line is required."));
        }
        
        if (string.IsNullOrWhiteSpace(address.City))
        {
            state.FailedWith(ValidationFailure.New(Field(nameof(address.City)), "City is required."));
        }
        
        var country = CountryRegistry.For(address.CountryCode);

        if (country is null)
        {
            state.FailedWith(ValidationFailure.New(Field(nameof(address.CountryCode)), "Unsupported country."));
        }
        else
        {
            if (country.PostalCode is PostalCodeRequirement.Required
                && string.IsNullOrWhiteSpace(address.PostalCode))
            {
                state.FailedWith(ValidationFailure.New(Field(nameof(address.PostalCode)), $"{country.PostalCodeLabel} is required."));
            }
        
            if (country.HasRegion
                && string.IsNullOrWhiteSpace(address.Region))
            {
                state.FailedWith(ValidationFailure.New(Field(nameof(address.Region)), $"{country.RegionLabel} is required."));
            }
        }

        PhoneNumberValidator.Validate(address.PhoneNumber, address.CountryCode, state, prefix);

        return state;

        string Field(string field) => prefix is null ? field : $"{prefix}.{field}";
    }
}