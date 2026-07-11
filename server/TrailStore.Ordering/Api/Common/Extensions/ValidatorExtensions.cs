using FluentValidation;
using TrailStore.Ordering.Api.Common.PostalAddress;
using TrailStore.Ordering.Domain.Addresses;
using TrailStore.Shared.Domain.Validation;

namespace TrailStore.Ordering.Api.Common.Extensions;

public static class ValidatorExtensions
{
    public static void ValidateAddress<T>(this IRuleBuilder<T, PostalAddressRequest> builder, string? prefix = null)
    {
        builder.Custom((address, context) =>
        {
            var state = AddressValidator.Validate(address.ToPostalAddress(), scope: new ValidationScope { Prefix = prefix});
            state.Map(failure => context.AddFailure(failure.Field, failure.Message));
        });
    }
}