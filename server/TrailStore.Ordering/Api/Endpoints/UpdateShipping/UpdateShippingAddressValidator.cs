using FastEndpoints;
using FluentValidation;
using TrailStore.Ordering.Api.Common.Extensions;

namespace TrailStore.Ordering.Api.Endpoints.UpdateShipping;

public sealed class UpdateShippingAddressValidator : Validator<UpdateShippingAddressRequest>
{
    public UpdateShippingAddressValidator()
    {
        RuleFor(request => request)
            .NotNull()
            .ValidateAddress("shipping_address");
    }
}