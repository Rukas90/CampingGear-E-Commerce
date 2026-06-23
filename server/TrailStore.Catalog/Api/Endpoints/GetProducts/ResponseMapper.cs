using TrailStore.Catalog.Application.Contracts;

namespace TrailStore.Catalog.Api.Endpoints.GetProducts;

public static class ResponseMapper
{
    public static ProductSummaryResponse[] ToResponses(this IEnumerable<ProductSummary> summaries)
        => summaries.Select(ToResponse).ToArray();
    
    public static ProductSummaryResponse ToResponse(this ProductSummary summary)
        => new()
        {
            Name = summary.Name,
            Slug = summary.Slug,
            BrandName = summary.BrandName,
            BrandSlug = summary.BrandSlug,
            CategoryName = summary.CategoryName,
            CategorySlug = summary.CategorySlug,
            DefaultSkuCode = summary.DefaultSkuCode,
            MinPrice = summary.MinPrice,
            MaxPrice = summary.MaxPrice,
            AverageRating = summary.AverageRating,
            ReviewCount = summary.ReviewCount,
            InStock = summary.InStock,
            HasVariants = summary.HasVariants,
            ThumbnailUrl = summary.ThumbnailUrl,
        };
}