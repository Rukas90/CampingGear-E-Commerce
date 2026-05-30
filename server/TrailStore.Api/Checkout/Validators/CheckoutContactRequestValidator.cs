using FastEndpoints;
using FluentValidation;
using TrailStore.Api.Checkout.Dto;

namespace TrailStore.Api.Checkout.Validators;

public class CheckoutContactRequestValidator : Validator<CheckoutContactRequest>
{
    public CheckoutContactRequestValidator()
    {
        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Please enter a valid email address.");
    }
}