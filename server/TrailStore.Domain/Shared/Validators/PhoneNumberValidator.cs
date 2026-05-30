using PhoneNumbers;
using TrailStore.Shared.Validation;

namespace TrailStore.Domain.Shared.Validators;

// ReSharper disable UnusedMethodReturnValue.Global

public static class PhoneNumberValidator
{
    private static readonly PhoneNumberUtil PhoneUtil 
        = PhoneNumberUtil.GetInstance();
    
    public static ValidationState Validate(string phoneNumber, string countryCode, ValidationState? state = null, string? prefix = null)
    {
        state ??= ValidationState.Ok();
        
        if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(countryCode))
        {
            return state.FailedWith(ValidationFailure.New(Field("PhoneNumber"), "Phone number is required."));
        }
            
        try
        {
            var parsed = PhoneUtil.Parse(phoneNumber, countryCode);
            var isValid = PhoneUtil.IsValidNumber(parsed);

            if (!isValid)
            {
                return state.FailedWith(ValidationFailure.New(Field("PhoneNumber"), "Phone number is invalid."));
            }
            
            return state;
        }
        catch (NumberParseException)
        {
            return state.FailedWith(ValidationFailure.New(Field("PhoneNumber"), "Phone number is invalid."));
        }
        
        string Field(string field) => prefix is null ? field : $"{prefix}.{field}";
    }
}