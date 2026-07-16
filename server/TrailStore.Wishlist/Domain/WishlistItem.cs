using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Wishlist.Domain;

public sealed class WishlistItem : IModel<WishlistItem>, IEntityCreatable
{
    public required Id<WishlistItem> Id { get; init; }
    public required Id<CustomerWishlist> WishlistId { get; init; }
    public required Id<SkuRef> SkuId { get; init; }
    
    public DateTime CreatedAt { get; set; }

    public static WishlistItem Create(Id<CustomerWishlist> wishlistId, Id<SkuRef> skuId)
        => new()
        {
            Id = Id<WishlistItem>.New(),
            WishlistId = wishlistId,
            SkuId = skuId,
        };
}