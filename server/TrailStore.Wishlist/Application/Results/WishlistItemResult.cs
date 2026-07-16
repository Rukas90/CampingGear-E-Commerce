using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Wishlist.Application.Results;

public sealed class WishlistItemResult
{
    public required Id<SkuRef> SkuId { get; init; }
    public required string BrandName { get; init; }
    public required string ProductName { get; init; }
    public required string ProductSlug { get; init; }
    public required string SkuCode { get; init; }
    public required decimal UnitPrice { get; init; }
    public required string VariantLine { get; init; }
    public string? ThumbnailUrl { get; init; }
}