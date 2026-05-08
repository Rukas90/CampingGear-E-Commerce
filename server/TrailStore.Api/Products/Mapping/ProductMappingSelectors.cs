using System.Linq.Expressions;
using TrailStore.Api.Products.Dto;
using TrailStore.Domain.Models;

namespace TrailStore.Api.Products.Mapping;

public static class ProductMappingSelectors
{
    public static Expression<Func<Product, ProductSummaryDto>> ToSummaryDto()
    {
        return product => new ProductSummaryDto
        {
            Name          = product.Name,
            Slug          = product.Slug,
            BrandName     = product.Brand.Name,
            BrandSlug     = product.Brand.Slug,
            Category      = product.Category.Slug,
            MinPrice      = product.Skus.Min(sku => (decimal?)sku.UnitPrice) ?? 0m,
            MaxPrice      = product.Skus.Max(sku => (decimal?)sku.UnitPrice) ?? 0m,
            AverageRating = product.Reviews.Average(r => (double?)r.Rating) ?? 0.0,
            ReviewCount   = product.Reviews.Count,
            InStock       = product.Skus.Any(sku => sku.Stock > 0),
            ThumbnailUrl  = product.ThumbnailUrl
        };
    }
    public static Expression<Func<Product, ProductDetailDto>> ToDetailDto()
    {
        return product => new ProductDetailDto
        {
            Name          = product.Name,
            Slug          = product.Slug,
            BrandName     = product.Brand.Name,
            BrandSlug     = product.Brand.Slug,
            Category      = product.Category.Slug,
            MinPrice      = product.Skus.Min(sku => (decimal?)sku.UnitPrice) ?? 0m,
            MaxPrice      = product.Skus.Max(sku => (decimal?)sku.UnitPrice) ?? 0m,
            AverageRating = product.Reviews.Average(r => (double?)r.Rating) ?? 0.0,
            ReviewCount   = product.Reviews.Count,
            InStock       = product.Skus.Any(sku => sku.Stock > 0),
            ThumbnailUrl  = product.ThumbnailUrl,
            Description   = product.Description,
            Skus          = product.Skus.Select(sku => new ProductSkuDto
            {
                CodeHash  = sku.CodeHash,
                UnitPrice = sku.UnitPrice,
                Stock     = sku.Stock,
                OptionIds = sku.Options.Select(option => option.Id).ToArray()
                
            }).ToArray(),
            Options = product.Skus
                .SelectMany(sku => sku.Options)
                .GroupBy(option => new 
                {
                    option.OptionGroup.Slug, option.OptionGroup.Name, option.OptionGroup.SortOrder
                })
                .Select(group => new ProductOptionGroupDto
            {
                Name      = group.Key.Name,
                SortOrder = group.Key.SortOrder,
                Options   = group.Select(option => new ProductOptionDto
                {
                    Id           = option.Id,
                    Name         = option.Name,
                    InStock      = product.Skus
                        .Where(sku => sku.Options.Any(o => o.Id == option.Id)).Any(sku => sku.Stock > 0),
                    PreviewType  = option.PreviewType,
                    PreviewValue = option.PreviewValue
                }).ToArray()
            }).ToArray(),
            Images = product.Images.Select(image => new ProductImageDto
            {
                OptionId = image.OptionId,
                Urls     = image.Urls.Select(url => new ProductImageUrlDto
                {
                    Url       = url.Url,
                    SortOrder = url.SortOrder
                }).ToArray()
            }).ToArray()
        };
    }
}