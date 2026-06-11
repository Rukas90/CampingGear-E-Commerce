using System.ComponentModel.DataAnnotations;
using TrailStore.Domain.Checkout.Errors;
using TrailStore.Domain.Countries.Data;
using TrailStore.Domain.Countries.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.Shared.Validators;
using TrailStore.Shared.Common;
using TrailStore.Shared.Validation;

namespace TrailStore.Domain.Checkout.Validators;

public static class CheckoutSessionValidator
{
    public record ValidatedCheckout(
        string EmailAddress,
        Country Country,
        PostalAddress ShippingAddress,
        PostalAddress BillingAddress,
        Id<ShippingMethod> ShippingMethodId
    ); 
    
    private static readonly EmailAddressAttribute EmailAttribute = new();
    
    public static Result<ValidatedCheckout> Validate(CheckoutSession session)
    {
        var state = ValidateContact(session);
        if (!state.IsValid) return CheckoutProblems.IncompleteCheckout(state);

        state = ValidateShippingAddress(session);
        if (!state.IsValid) return CheckoutProblems.IncompleteCheckout(state);

        state = ValidateShippingMethod(session);
        if (!state.IsValid) return CheckoutProblems.IncompleteCheckout(state);

        state = ValidateBillingAddress(session);
        if (!state.IsValid) return CheckoutProblems.IncompleteCheckout(state);
        
        var billingAddress = session.ShippingAddressAsBillingAddress
            ? session.ShippingAddress!
            : session.BillingAddress!;
        
        return new ValidatedCheckout(
            EmailAddress: session.EmailAddress!,
            Country: CountryRegistry.For(session.ShippingAddress!.CountryCode)!,
            ShippingAddress: session.ShippingAddress!,
            BillingAddress: billingAddress,
            ShippingMethodId: session.ShippingMethodId!.Value
        );
    }

    private static ValidationState ValidateContact(CheckoutSession session)
    {
        var state = ValidationState.Ok(scope: new ValidationScope
        {
            Prefix = "contact"
        });

        if (string.IsNullOrWhiteSpace(session.EmailAddress) || !EmailAttribute.IsValid(session.EmailAddress))
        {
            state.FailedWith(ValidationFailure.New("emailAddress", "Valid email address is required."));
        }

        return state;
    }

    private static ValidationState ValidateShippingAddress(CheckoutSession session)
    {
        var state = ValidationState.Ok(scope: new ValidationScope
        {
            Prefix = "shipping_address"
        });
        
        AddressValidator.Validate(session.ShippingAddress, state);
        
        if (state.IsValid && CountryRegistry.For(session.ShippingAddress!.CountryCode) is null)
        {
            state.FailedWith(ValidationFailure.New("countryCode", "Please select a valid country."));
        }

        return state;
    }
    
    private static ValidationState ValidateShippingMethod(CheckoutSession session)
    {
        var state = ValidationState.Ok(scope: new ValidationScope
        {
            Prefix = "shipping_method"
        });
        
        if (session.ShippingMethodId is null)
        {
            state.FailedWith(ValidationFailure.New(field: "Required", message: "Shipping method is required."));
        }
        
        return state;
    }

    private static ValidationState ValidateBillingAddress(CheckoutSession session)
    {
        var state = ValidationState.Ok(scope: new ValidationScope
        {
            Prefix = "billing_address"
        });
        
        if (!session.ShippingAddressAsBillingAddress)
        {
            AddressValidator.Validate(session.BillingAddress, state);
        }

        return state;
    }
}