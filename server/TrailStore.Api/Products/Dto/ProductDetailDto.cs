namespace TrailStore.Api.Products.Dto;

public sealed class ProductDetailDto : ProductSummaryDto
{
    public int RecommendedCount { get; init; } = 0;
    public Dictionary<int, int> StarCounts { get; init; } = [];
    public string? Description { get; init; }
    public ProductSkuDto[] Skus { get; init; } = [];
    public ProductOptionGroupDto[] Options { get; init; } = [];
    public ProductImageDto[] Images { get; init; } = [];
}