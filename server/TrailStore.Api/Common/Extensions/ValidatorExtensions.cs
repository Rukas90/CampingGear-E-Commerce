using FluentValidation;
using TrailStore.Api.Common.Dto;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Shared.Validators;

namespace TrailStore.Api.Common.Extensions;

public static class ValidatorExtensions
{
    public static void ValidateAddress<T>(this IRuleBuilder<T, PostalAddressRequest> builder)
    {
        builder.Custom((address, context) =>
        {
            var state = AddressValidator.Validate(address.ToPostalAddress());
 
            foreach (var failure in state.Failures)
                context.AddFailure(failure.Field, failure.Message);
        });
    }
}