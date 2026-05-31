using FastEndpoints;
using FluentValidation;
using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Common.Extensions;

namespace TrailStore.Api.Checkout.Validators;

public class CheckoutBillingRequestValidator : Validator<UpdateBillingRequest>
{
    public CheckoutBillingRequestValidator()
    {
        When(x => x.AsShippingAddress == false, () =>
        {
            RuleFor(x => x.Address)
                .NotNull()
                .DependentRules(() =>
                {
                    RuleFor(x => x.Address!)
                        .ValidateAddress();
                });
        });
    }
}