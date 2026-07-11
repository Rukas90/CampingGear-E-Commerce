using FastEndpoints;
using FluentValidation;
using TrailStore.Ordering.Api.Common.Extensions;

namespace TrailStore.Ordering.Api.Endpoints.UpdateBilling;

public sealed class UpdateBillingValidator : Validator<UpdateBillingRequest>
{
    public UpdateBillingValidator()
    {
        When(x => x.AsShippingAddress == false, () =>
        {
            RuleFor(x => x.Address)
                .NotNull()
                .DependentRules(() =>
                {
                    RuleFor(x => x.Address!)
                        .ValidateAddress("billing_address");
                });
        });
    }
}