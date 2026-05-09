namespace TrailStore.Api.Products.Dto;

public sealed class ProductDetailDto : ProductSummaryDto
{
    public string?                 Description { get; init; }
    public ProductSkuDto[]         Skus        { get; init; } = [];
    public ProductOptionGroupDto[] Options     { get; init; } = [];
    public ProductImageDto[]       Images      { get; init; } = [];
}