using TrailStore.Basket.Domain.Carts;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Results;

public class CartItemResult
{
    public required Id<CartItem> Id { get; init; }
    public required int Quantity { get; init; }
    public required string ProductName { get; init; }
    public required Slug ProductSlug { get; init; }
    public required string BrandName { get; init; }
    public required Slug BrandSlug { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; init; }
    public string? ThumbnailUrl { get; init; }
    public required ItemOptionResult[] Options { get; init; }
}