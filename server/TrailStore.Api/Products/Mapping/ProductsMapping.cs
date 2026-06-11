using TrailStore.Api.Products.Dto;
using TrailStore.Domain.Products.Enums;
using TrailStore.Domain.Products.Models;
using TrailStore.Domain.Shared.Enums;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Products.Mapping;

public static class ProductsMapping
{
    public static ProductDetailDto ToDetailDto(this Product product)
    {
        return new ProductDetailDto
        {
            Name = product.Name,
            Slug = product.Slug,
            BrandName = product.Brand.Name,
            BrandSlug = product.Brand.Slug,
            CategoryName = product.Category.Name,
            CategorySlug = product.Category.Slug,
            DefaultSkuCode = product.Skus.First().Code,
            MinPrice = product.Skus.Min(sku => (decimal?)sku.UnitPrice) ?? 0m,
            MaxPrice = product.Skus.Max(sku => (decimal?)sku.UnitPrice) ?? 0m,
            AverageRating = product.Reviews.Average(r => (double?)r.Rating) ?? 0.0,
            ReviewCount = product.Reviews.Count,
            InStock = product.Skus.Any(sku => sku.AvailableStock > 0),
            HasVariants = product.Skus.Count > 1,
            ThumbnailUrl = product.ThumbnailUrl,
            RecommendedCount = product.Reviews.Count(review => review.Recommended),
            StarCounts = MapStarCounts(product.Reviews),
            Description = product.Description,
            Skus = MapSkus(product.Skus),
            Options = MapOptionGroups(product),
            Images = MapImages(product.Images)
        };
    }
    
    private static Dictionary<int, int> MapStarCounts(IEnumerable<Review> reviews)
        => Enumerable.Range(1, 5)
            .ToDictionary(star => star, star => reviews.Count(r => r.Rating == star));
    
    private static ProductSkuDto[] MapSkus(IEnumerable<Sku> skus)
        => skus.Select(sku => new ProductSkuDto
        {
            Code = sku.Code.ToLower(),
            UnitPrice = sku.UnitPrice,
            Stock = sku.AvailableStock,
            OptionIds = sku.Options.Select(option => option.Id).ToArray()
        }).ToArray();
    
    private static ProductOptionGroupDto[] MapOptionGroups(Product product)
        => product.Skus
            .SelectMany(sku => sku.Options)
            .GroupBy(option => new
            {
                option.OptionGroup.Slug,
                option.OptionGroup.Name,
                option.OptionGroup.SortOrder
            })
            .Select(group => new ProductOptionGroupDto
            {
                Name = group.Key.Name,
                SortOrder = group.Key.SortOrder,
                Options = MapOptions(group, product.Skus)
            })
            .ToArray();
    
    private static ProductOptionDto[] MapOptions(
        IEnumerable<Option> options, ICollection<Sku> skus)
        => options
            .GroupBy(o => o.Id)
            .Select(g => g.First())
            .Select(option => new ProductOptionDto
            {
                Id = option.Id,
                Name = option.Name,
                SortOrder = option.SortOrder,
                InStock = skus.Any(sku =>
                    sku.Options.Any(o => o.Id == option.Id) && sku.AvailableStock > 0),
                PreviewType = option.PreviewType,
                PreviewValue = option.PreviewValue
            })
            .ToHashSet()
            .ToArray();
    
    private static ProductImageDto[] MapImages(IEnumerable<ProductImage> images)
        => images.Select(image => new ProductImageDto
        {
            OptionId = image.OptionId,
            Urls = image.Urls.Select(url => new ProductImageUrlDto
            {
                Url = url.Url,
                SortOrder = url.SortOrder
            }).ToArray()
        }).ToArray();

    public static ProductsFilter MapToFilter(this ProductsRequest request)
    {
        return new ProductsFilter
        {
            SortBy = request.SortBy ?? ProductsSortBy.Manual,
            BrandSlugs = request.Brand ?? [],
            CategorySlugs = request.Category ?? [],
            Pagination = request.Pagination ?? false,
            Page = request.Page ?? 0,
            PageSize = request.PageSize ?? 30,
            PriceGte = request.PriceGte ?? 0,
            PriceLte = request.PriceLte ?? decimal.MaxValue,
            Availability = request.Availability ?? Availability.All,
            Option = request.Option?
                .Select(kvp => new OptionSelection(kvp.Key, kvp.Value))
                .ToArray() ?? [],
            SkuCode = request.SkuCode ?? [],
        };
    }
}