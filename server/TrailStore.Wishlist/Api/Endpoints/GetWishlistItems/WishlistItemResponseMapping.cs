using TrailStore.Wishlist.Application.Results;

namespace TrailStore.Wishlist.Api.Endpoints.GetWishlistItems;

public static class WishlistItemResponseMapping
{
    public static WishlistItemResponse[] ToResponses(this IEnumerable<WishlistItemResult> items)
        => items.Select(ToResponse).ToArray();
    
    public static WishlistItemResponse ToResponse(this WishlistItemResult item)
        => new()
        {
            SkuId = item.SkuId,
            BrandName = item.BrandName,
            ProductName = item.ProductName,
            ProductSlug = item.ProductSlug,
            SkuCode = item.SkuCode,
            VariantLine = item.VariantLine,
            UnitPrice = item.UnitPrice,
            ThumbnailUrl = item.ThumbnailUrl,
        };
}