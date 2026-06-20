namespace TrailStore.Catalog.Application.Contracts;

public class ProductDetails
{
    public required string Name { get; init; }
    public required string Slug { get; init; }
    public string? Description { get; init; }
    public required string BrandName { get; init; }
    public required string BrandSlug { get; init; }
    public required string CategoryName { get; init; }
    public required string CategorySlug { get; init; }
    public required string DefaultSkuCode { get; init; }
    public required decimal MinPrice { get; init; }
    public required decimal MaxPrice { get; init; }
    public required double AverageRating { get; init; }
    public required int ReviewCount { get; init; }
    public required bool InStock { get; init; }
    public required bool HasVariants { get; init; }
    public string? ThumbnailUrl { get; init; }
    public int RecommendedCount { get; init; } = 0;
    public Dictionary<int, int> StarCounts { get; init; } = [];
    public ProductSku[] Skus { get; init; } = [];
    public ProductOptionGroup[] Options { get; init; } = [];
    public ProductDetailsImage[] Images { get; init; } = [];
}