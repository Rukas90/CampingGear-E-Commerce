using PhoneNumbers;
using TrailStore.Shared.Domain.Validation;

namespace TrailStore.Ordering.Domain.Addresses;

// ReSharper disable UnusedMethodReturnValue.Global

public static class PhoneNumberValidator
{
    private static readonly PhoneNumberUtil PhoneUtil 
        = PhoneNumberUtil.GetInstance();
    
    public static ValidationState Validate(string? phoneNumber, string? countryCode, ValidationState? state = null, ValidationScope? scope = null)
    {
        state ??= ValidationState.Ok(scope);
        
        if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(countryCode))
        {
            return state.FailedWith(ValidationFailure.New("PhoneNumber", "Phone number is required."));
        }
            
        try
        {
            var parsed = PhoneUtil.Parse(phoneNumber, countryCode);
            var isValid = PhoneUtil.IsValidNumber(parsed);

            if (!isValid)
            {
                return state.FailedWith(ValidationFailure.New("PhoneNumber", "Phone number is invalid."));
            }
            
            return state;
        }
        catch (NumberParseException)
        {
            return state.FailedWith(ValidationFailure.New("PhoneNumber", "Phone number is invalid."));
        }
    }
}