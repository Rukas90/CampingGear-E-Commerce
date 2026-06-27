using TrailStore.Catalog.Application.Results;
using TrailStore.Catalog.Domain.Options;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews.Models;
using TrailStore.Catalog.Domain.Reviews.Repositories;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Application.Queries.GetProduct;

[AppService<GetProductQueryHandler>]
public class GetProductQueryHandler(
    IProductsRepository productsRepository,
    IReviewRepository reviewRepository) 
    : IQueryHandler<GetProductQuery, ProductDetailsResult>
{
    public async Task<Result<ProductDetailsResult>> Handle(GetProductQuery query, CancellationToken ct)
    {
        var product = await productsRepository.GetFullProductAsync(Slug.Create(query.Slug), ct);

        if (product is null)
        {
            return ProductProblems.NotFoundBySlug(query.Slug);
        }
        
        var reviews = await reviewRepository.ListAsync(product.Id, ct);

        return new ProductDetailsResult
        {
            Name = product.Name,
            Slug = product.Slug,
            Description = product.Description,
            BrandName = product.Brand.Name,
            BrandSlug = product.Brand.Slug,
            CategoryName = product.Category.Name,
            CategorySlug = product.Category.Slug,
            ReviewCount = reviews.Count,
            AverageRating = reviews.Average(review => (double?)review.Rating) ?? 0.0,
            DefaultSkuCode = product.Skus[0].Code,
            MinPrice = product.Skus.Min(sku => (decimal?)sku.UnitPrice) ?? 0m,
            MaxPrice = product.Skus.Max(sku => (decimal?)sku.UnitPrice) ?? 0m,
            InStock = product.Skus.Any(sku => sku.AvailableStock > 0),
            HasVariants = product.Skus.Count > 1,
            ThumbnailUrl = product.ThumbnailUrl,
            RecommendedCount = reviews.Count(review => review.Recommended),
            StarCounts = MapStarCounts(reviews),
            Skus = MapSkus(product.Skus),
            Options = MapOptionGroups(product.Skus),
            Images = MapImages(product.Images)
        };
    }
    
    private static Dictionary<int, int> MapStarCounts(IEnumerable<Review> reviews)
        => Enumerable.Range(1, 5)
            .ToDictionary(star => star, star => reviews.Count(r => r.Rating == star));
    
    private static ProductSkuResult[] MapSkus(IEnumerable<Sku> skus)
        => skus.Select(sku => new ProductSkuResult
        {
            Id = sku.Id,
            Code = sku.Code,
            UnitPrice = sku.UnitPrice,
            Stock = sku.AvailableStock,
            OptionIds = sku.Options.Select(option => option.Id.Value).ToArray()
        }).ToArray();
    
    private static ProductOptionGroupResult[] MapOptionGroups(IReadOnlyList<Sku> skus)
        => skus
            .SelectMany(sku => sku.Options)
            .GroupBy(option => new
            {
                option.OptionGroup.Slug,
                option.OptionGroup.Name,
                option.OptionGroup.SortOrder
            })
            .Select(group => new ProductOptionGroupResult
            {
                Name = group.Key.Name,
                SortOrder = group.Key.SortOrder,
                Options = MapOptions(group, skus)
            })
            .ToArray();
    
    private static ProductOptionResult[] MapOptions(IEnumerable<Option> options, IReadOnlyList<Sku> skus)
        => options
            .GroupBy(o => o.Id)
            .Select(g => g.First())
            .Select(option => new ProductOptionResult
            {
                Name = option.Name,
                SortOrder = option.SortOrder,
                InStock = skus.Any(sku =>
                    sku.Options.Any(o => o.Id == option.Id) && sku.AvailableStock > 0),
                PreviewType = option.PreviewType,
                PreviewValue = option.PreviewValue
            })
            .ToHashSet()
            .ToArray();
    
    private static ProductImageResult[] MapImages(IEnumerable<ProductImage> images)
        => images.Select(image => new ProductImageResult
        {
            OptionId = image.OptionId,
            Urls = image.Urls.Select(url => new ProductImageUrlResult
            {
                Url = url.Url,
                SortOrder = url.SortOrder
            }).ToArray()
        }).ToArray();
}