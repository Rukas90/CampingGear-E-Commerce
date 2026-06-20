using TrailStore.Catalog.Application.Abstractions;
using TrailStore.Catalog.Application.Contracts;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Application.Queries.GetProducts;

public class GetProductsQueryHandler(
    IProductsQueryBuilder queryBuilder,
    IReviewRepository reviewRepository,
    IProductsRepository productsRepository) 
    : IQueryHandler<GetProductsQuery, ProductSummary[]>
{
    public async Task<Result<ProductSummary[]>> Handle(GetProductsQuery query, CancellationToken ct)
    {
        var filter = query.ToFilter();
        
        var products = await productsRepository.ListAsync(
            queryBuilder.Build(filter),
            product => new
            {
                product.Id,
                product.Name,
                product.Slug,
                BrandName = product.Brand.Name,
                BrandSlug = product.Brand.Slug,
                CategoryName = product.Category.Name,
                CategorySlug = product.Category.Slug,
                DefaultSkuCode = product.Skus.First().Code,
                MinPrice = product.Skus.Min(sku => (decimal?)sku.UnitPrice) ?? 0m,
                MaxPrice = product.Skus.Max(sku => (decimal?)sku.UnitPrice) ?? 0m,
                InStock = product.Skus.Any(sku => sku.Stock - sku.Reserved > 0),
                HasVariants = product.Skus.Count > 1,
                product.ThumbnailUrl
            },
            ct);

        var reviewSummaries = await reviewRepository.GetReviewsSummariesAsync(
            products.Select(p => p.Id), ct);
        
        var summaries = products
            .Select(p =>
            {
                var reviewSummary 
                    = reviewSummaries.FirstOrDefault(summary => summary.ProductId == p.Id);
                
                return new ProductSummary
                {
                    Name = p.Name,
                    Slug = p.Slug,
                    BrandName = p.BrandName,
                    BrandSlug = p.BrandSlug,
                    CategoryName = p.CategoryName,
                    CategorySlug = p.CategorySlug,
                    ReviewCount = reviewSummary?.ReviewsCount ?? 0,
                    AverageRating = reviewSummary?.AverageRating ?? 0.0,
                    DefaultSkuCode = p.DefaultSkuCode,
                    MinPrice = p.MinPrice,
                    MaxPrice = p.MaxPrice,
                    InStock = p.InStock,
                    HasVariants = p.HasVariants,
                    ThumbnailUrl = p.ThumbnailUrl
                };
            })
            .ToArray();
        
        return summaries;
    }
}