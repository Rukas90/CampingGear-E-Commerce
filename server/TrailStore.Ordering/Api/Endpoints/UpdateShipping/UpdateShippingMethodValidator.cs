using FastEndpoints;
using FluentValidation;

namespace TrailStore.Ordering.Api.Endpoints.UpdateShipping;

public sealed class UpdateShippingMethodValidator : Validator<UpdateShippingMethodRequest>
{
    public UpdateShippingMethodValidator()
    {
        RuleFor(x => x.ShippingMethodId)
            .NotEmpty().WithMessage("Shipping method is required.");
    }
}