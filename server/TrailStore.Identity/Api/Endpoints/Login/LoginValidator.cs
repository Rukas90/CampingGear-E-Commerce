using FastEndpoints;
using FluentValidation;

namespace TrailStore.Identity.Api.Endpoints.Login;

public class LoginValidator : Validator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress();
        
        RuleFor(x => x.Password)
            .NotEmpty();
    }
}