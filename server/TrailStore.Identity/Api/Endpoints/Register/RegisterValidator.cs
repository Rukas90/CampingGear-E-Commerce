using FastEndpoints;
using FluentValidation;

namespace TrailStore.Identity.Api.Api.Endpoints.Register;

public class RegisterValidator : Validator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(r => r.Email)
            .EmailAddress();
        
        RuleFor(r => r.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(64);
    }
}