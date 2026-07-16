using FastEndpoints;
using FluentValidation;

namespace TrailStore.Wishlist.Api.Endpoints.AddToWishlist;

public sealed class AddToWishlistValidator : Validator<AddToWishlistRequest>
{
    public AddToWishlistValidator()
    {
        RuleFor(x => x.SkuId)
            .NotNull().WithMessage("Sku Id is required.");
    }
}