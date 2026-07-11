using FastEndpoints;
using FluentValidation;
using TrailStore.Ordering.Api.Common.Extensions;

namespace TrailStore.Ordering.Api.Common.PostalAddress;

public class PostalAddressRequestValidator : Validator<PostalAddressRequest>
{
    public PostalAddressRequestValidator()
    {
        RuleFor(request => request)
            .NotNull()
            .ValidateAddress();
    }
}