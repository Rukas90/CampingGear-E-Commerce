namespace TrailStore.Api.Carts.Dto;

public class CartSkusDto
{
    public required string Code { get; init; }
    public required string ProductName { get; init; }
    public required string ProductSlug { get; init; }
    public required string ThumbnailUrl { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; init; }
    public required CartSkuOptionDto[] Options { get; init; }
}