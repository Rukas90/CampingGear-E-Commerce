using TrailStore.Catalog.Api.Endpoints.GetProduct.Responses;
using TrailStore.Catalog.Application.Results;

namespace TrailStore.Catalog.Api.Endpoints.GetProduct;

public static class GetProductResponseMappers
{
    public static ProductDetailsResponse ToResponse(this ProductDetailsResult details)
        => new()
        {
            Name = details.Name,
            Slug = details.Slug,
            BrandName = details.BrandName,
            BrandSlug = details.BrandSlug,
            CategoryName = details.CategoryName,
            CategorySlug = details.CategorySlug,
            DefaultSkuCode = details.DefaultSkuCode,
            MinPrice = details.MinPrice,
            MaxPrice = details.MaxPrice,
            AverageRating = details.AverageRating,
            ReviewCount = details.ReviewCount,
            InStock =  details.InStock,
            HasVariants = details.HasVariants,
            ThumbnailUrl = details.ThumbnailUrl,
            RecommendedCount = details.RecommendedCount,
            StarCounts = details.StarCounts,
            Description = details.Description,
            Skus = details.Skus.Select(MapSkuResponse).ToArray(),
            Options = details.Options.Select(MapOptionGroupResponse).ToArray(),
            Images = details.Images.Select(MapProductImageResponse).ToArray()
        };

    private static ProductSkuResponse MapSkuResponse(this ProductSkuResult sku)
        => new()
        {
            Id = sku.Id,
            Code = sku.Code,
            UnitPrice = sku.UnitPrice,
            Stock = sku.Stock,
            OptionIds = sku.OptionIds,
        };
    
    private static ProductOptionGroupResponse MapOptionGroupResponse(this ProductOptionGroupResult optionGroup)
        => new()
        {
            Name = optionGroup.Name,
            SortOrder = optionGroup.SortOrder,
            Options = optionGroup.Options.Select(MapOptionResponse).ToArray()
        };

    private static ProductOptionResponse MapOptionResponse(this ProductOptionResult option)
        => new()
        {
            Id = option.Id,
            Name = option.Name,
            SortOrder = option.SortOrder,
            InStock = option.InStock,
            PreviewType = option.PreviewType,
            PreviewValue = option.PreviewValue,
        };

    private static ProductImageResponse MapProductImageResponse(this ProductImageResult image)
        => new()
        {
            OptionId = image.OptionId,
            Urls = image.Urls.Select(url => new ProductImageUrlResponse
            {
                Url = url.Url,
                SortOrder = url.SortOrder
            }).ToArray()
        };
}