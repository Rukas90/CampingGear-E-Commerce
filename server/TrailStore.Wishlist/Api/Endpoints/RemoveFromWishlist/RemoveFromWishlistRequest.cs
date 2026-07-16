using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Wishlist.Api.Endpoints.RemoveFromWishlist;

public sealed class RemoveFromWishlistRequest
{
    public Id<SkuRef> SkuId { get; set; }
}