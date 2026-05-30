namespace TrailStore.Api.Carts.Dto;

public class CartItemDto
{
    public required string Code { get; init; }
    public required int Quantity { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; init; }
    public required string BrandName { get; init; }
    public required string BrandSlug { get; init; }
    public required string ProductName { get; init; }
    public required string ProductSlug { get; init; }
    public required string ThumbnailUrl { get; init; }
    public required CartItemOptionDto[] Options { get; init; }
}