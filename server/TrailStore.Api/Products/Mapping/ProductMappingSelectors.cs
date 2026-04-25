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
            Brand         = product.Brand.Slug,
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
            Brand         = product.Brand.Slug,
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
                Id     = sku.Id,
                UnitPrice = sku.UnitPrice,
                Stock     = sku.Stock,
                Options   = sku.Options.Select(option => new SkuOptionDto
                {
                    Slug        = option.Slug,
                    OptionGroup = option.OptionGroup.Slug
                }).ToArray() 
            }).ToArray()
            // TODO: IMAGES (OR LOAD LAZILY ON CLIENT DEPENDING ON SELECTED OPTION?)
        };
    }
}