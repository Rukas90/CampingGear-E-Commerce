using TrailStore.Basket.Domain.Carts;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Endpoints.GetCart;

public sealed class CartItemResponse
{
    public required Id<CartItem> Id { get; init; }
    public required Id<SkuRef> SkuId { get; init; }
    public required int Quantity { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; init; }
    public required string BrandName { get; init; }
    public required string BrandSlug { get; init; }
    public required string ProductName { get; init; }
    public required string ProductSlug { get; init; }
    public string? ThumbnailUrl { get; init; }
    public required CartItemOptionResponse[] Options { get; init; }
}