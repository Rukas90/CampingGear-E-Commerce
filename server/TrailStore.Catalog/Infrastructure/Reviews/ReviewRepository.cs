using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews.Enums;
using TrailStore.Catalog.Domain.Reviews.Inputs;
using TrailStore.Catalog.Domain.Reviews.Models;
using TrailStore.Catalog.Domain.Reviews.Projections;
using TrailStore.Catalog.Domain.Reviews.Repositories;
using TrailStore.Catalog.Domain.Reviews.Specifications;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Catalog.Infrastructure.Reviews;

[AppService<IReviewRepository>]
public class ReviewRepository(CatalogDbContext _context) 
    : AggregateRepository<Review, CatalogDbContext>(_context), IReviewRepository
{
    public async Task<List<Review>> ListAsync(ReviewsFilter filter, CancellationToken ct)
    {
        var queryable = AggregateReadQuery.AsQueryable();

        var specification = ReviewsSpecificationBuilder.Build(filter);

        queryable = queryable.Where(specification.ToExpression());
        queryable = GetOrderedQueryable(queryable, filter.SortBy);

        queryable = filter.Pagination
            ? queryable.Skip(filter.Page * filter.PageSize).Take(filter.PageSize)
            : queryable;

        return await queryable
            .ToListAsync(ct);
    }

    private static IQueryable<Review> GetOrderedQueryable(
        IQueryable<Review> query, ReviewsSortBy sortBy)
    {
        return sortBy switch
        {
            ReviewsSortBy.MostRecent => query.OrderByDescending(review => review.CreatedAt),
            ReviewsSortBy.HighestRating => query.OrderByDescending(review => review.Rating),
            ReviewsSortBy.LowestRating => query.OrderBy(review => review.Rating),
            ReviewsSortBy.MostHelpful => query.OrderByDescending(review => review.Votes.Count(v => v.IsLike)),
            _ => query
        };
    }
    
    public Task<List<Review>> ListAsync(Id<Product> productId, CancellationToken ct)
        => AggregateReadQuery.Where(review => review.ProductId == productId).ToListAsync(ct);

    public async Task<ReviewsSummary[]> GetReviewsSummariesAsync(
        IEnumerable<Id<Product>> productIds, CancellationToken ct)
    {
        var ids = productIds.ToList();

        return await AggregateReadQuery
            .Where(review => ids.Contains(review.ProductId))
            .GroupBy(review => review.ProductId)
            .Select(g => new ReviewsSummary(
                g.Key, g.Count(),
                AverageRating: Math.Round(g.Average(r => (double)r.Rating), 1)))
            .ToArrayAsync(ct);
    }

    protected override IQueryable<Review> BuildAggregateQuery(DbSet<Review> set)
        => set.Include(review => review.Votes);
}