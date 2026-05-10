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
            CategoryName  = product.Category.Name,
            CategorySlug  = product.Category.Slug,
            MinPrice      = product.Skus.Min(sku => (decimal?)sku.UnitPrice) ?? 0m,
            MaxPrice      = product.Skus.Max(sku => (decimal?)sku.UnitPrice) ?? 0m,
            AverageRating = product.Reviews.Average(r => (double?)r.Rating) ?? 0.0,
            ReviewCount   = product.Reviews.Count,
            InStock       = product.Skus.Any(sku => sku.Stock > 0),
            ThumbnailUrl  = product.ThumbnailUrl
        };
    }
}