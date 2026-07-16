using FastEndpoints;
using FluentValidation;

namespace TrailStore.Wishlist.Api.Endpoints.RemoveFromWishlist;

public sealed class RemoveFromWishlistValidator : Validator<RemoveFromWishlistRequest>
{
    public RemoveFromWishlistValidator()
    {
        RuleFor(x => x.SkuId)
            .NotNull().WithMessage("Sku Id is required.");
    }
}