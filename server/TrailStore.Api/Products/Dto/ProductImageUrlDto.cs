namespace TrailStore.Api.Products.Dto;

public sealed class ProductImageUrlDto
{
    public required string Url { get; init; }
    public required int SortOrder { get; init; }
}