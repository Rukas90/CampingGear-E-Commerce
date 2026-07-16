using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Wishlist.Api.Endpoints.AddToWishlist;

public sealed class AddToWishlistRequest
{
    public Id<SkuRef> SkuId { get; set; }
}