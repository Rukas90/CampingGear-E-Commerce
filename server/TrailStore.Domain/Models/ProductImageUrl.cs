using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class ProductImageUrl : IModel<ProductImageUrl>
{
    public Id<ProductImageUrl> Id             { get; init; }
    public Id<ProductImage>    ProductImageId { get; init; }
    public required string     Url            { get; init; }
    public int                 SortOrder      { get; init; }
    
    public static ProductImageUrl Create(
        Id<ProductImageUrl> id,
        Id<ProductImage>    productImageId, 
        string              url, 
        int                 sortOrder)
        => new()
        {
            Id             = id,
            ProductImageId = productImageId,
            Url            = url,
            SortOrder      = sortOrder
        };
    
    public static ProductImageUrl Create(
        Id<ProductImage>    productImageId, 
        string              url, 
        int                 sortOrder)
        => new()
        {
            Id             = Id<ProductImageUrl>.Part(productImageId).Part(url).Build(),
            ProductImageId = productImageId,
            Url            = url,
            SortOrder      = sortOrder
        };
}