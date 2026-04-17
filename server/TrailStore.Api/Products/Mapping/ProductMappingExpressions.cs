using System.Linq.Expressions;
using TrailStore.Api.Products.Dto;
using TrailStore.Domain.Models;

namespace TrailStore.Api.Products.Mapping;

public static class ProductMappingExpressions
{
    public static Expression<Func<Product, ProductSummaryDto>> ToSummaryDto()
    {
        return product => new ProductSummaryDto
        {
            Id         = product.Id,
            Name          = product.Name,
            Slug          = product.Slug,
            BrandId    = product.BrandId,
            CategoryId = product.CategoryId,
            PriceGte      = product.Skus.Min(sku => (decimal?)sku.UnitPrice) ?? 0m,
            PriceLte      = product.Skus.Max(sku => (decimal?)sku.UnitPrice) ?? 0m,
            AverageRating = product.Reviews.Average(r => (double?)r.Rating) ?? 0.0,
            ReviewCount   = product.Reviews.Count,
            InStock       = product.Skus.Any(sku => sku.Stock > 0),
            ImageUrl      = product.Skus.First().ImageUrl
        };
    }
    public static Expression<Func<Product, ProductDetailDto>> ToDetailDto()
    {
        return product => new ProductDetailDto
        {
            Id         = product.Id,
            Name          = product.Name,
            Slug          = product.Slug,
            BrandId    = product.BrandId,
            CategoryId = product.CategoryId,
            PriceGte      = product.Skus.Min(sku => (decimal?)sku.UnitPrice) ?? 0m,
            PriceLte      = product.Skus.Max(sku => (decimal?)sku.UnitPrice) ?? 0m,
            AverageRating = product.Reviews.Average(r => (double?)r.Rating) ?? 0.0,
            ReviewCount   = product.Reviews.Count,
            InStock       = product.Skus.Any(sku => sku.Stock > 0),
            ImageUrl      = product.Skus.First().ImageUrl ?? string.Empty,
            Description   = product.Description,
            Skus          = product.Skus.Select(sku => new ProductSkuDto
            {
                Id     = sku.Id,
                UnitPrice = sku.UnitPrice,
                Stock     = sku.Stock,
                ImageUrl  = sku.ImageUrl,
                Options   = sku.Options.Select(option => new SkuOptionDto
                {
                    Id            = option.Id,
                    OptionGroupId = option.OptionGroupId
                }).ToArray() 
            }).ToArray()
        };
    }
}