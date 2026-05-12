using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class ProductImageUrl : IModel<ProductImageUrl>
{
    public Id<ProductImageUrl> Id { get; init; }
    public Id<ProductImage> ProductImageId { get; init; }
    public required string Url { get; init; }
    public int SortOrder { get; init; }

    public static ProductImageUrl Create(
        Id<ProductImage> productImageId,
        string url,
        int sortOrder)
    {
        return new ProductImageUrl
        {
            Id = Id<ProductImageUrl>.Part(productImageId).Part(url).Build(),
            ProductImageId = productImageId,
            Url = url,
            SortOrder = sortOrder
        };
    }
}