using FastEndpoints;
using FluentValidation;

namespace TrailStore.Ordering.Api.Endpoints.UpdateContact;

public sealed class UpdateContactValidator : Validator<UpdateContactRequest>
{
    public UpdateContactValidator()
    {
        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Please enter a valid email address.");
    }
}