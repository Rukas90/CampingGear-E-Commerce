namespace TrailStore.Catalog.Api.Endpoints.GetProduct.Responses;

public class ProductDetailsResponse
{
    public required string Name { get; init; }
    public required string Slug { get; init; }
    public required string BrandName { get; init; }
    public required string BrandSlug { get; init; }
    public required string CategoryName { get; init; }
    public required string CategorySlug { get; init; }
    public required string DefaultSkuCode { get; init; }
    public decimal MinPrice { get; init; }
    public decimal MaxPrice { get; init; }
    public double AverageRating { get; init; }
    public int ReviewCount { get; init; }
    public bool InStock { get; init; }
    public bool HasVariants { get; init; }
    public string? ThumbnailUrl { get; init; }
    public int RecommendedCount { get; init; } = 0;
    public Dictionary<int, int> StarCounts { get; init; } = [];
    public string? Description { get; init; }
    public ProductSkuResponse[] Skus { get; init; } = [];
    public ProductOptionGroupResponse[] Options { get; init; } = [];
    public ProductImageResponse[] Images { get; init; } = [];
}