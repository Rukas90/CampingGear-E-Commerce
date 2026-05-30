using FastEndpoints;
using FluentValidation;
using TrailStore.Api.Common.Dto;
using TrailStore.Api.Common.Extensions;

namespace TrailStore.Api.Common.Validators;

public class PostalAddressRequestValidator : Validator<PostalAddressRequest>
{
    public PostalAddressRequestValidator()
    {
        RuleFor(request => request)
            .NotNull()
            .ValidateAddress();
    }
}