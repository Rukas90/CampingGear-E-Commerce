using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Catalog.Infrastructure.Reviews;

[AppService<IReviewRepository>]
public class ReviewRepository(CatalogDbContext _context) 
    : AggregateRepository<Review, CatalogDbContext>(_context), IReviewRepository
{
    public Task<List<Review>> ListAsync(Id<Product> productId, CancellationToken ct)
        => AggregateReadQuery.Where(review => review.ProductId == productId).ToListAsync(ct);

    public async Task<ReviewsSummary[]> GetReviewsSummariesAsync(
        IEnumerable<Id<Product>> productIds, CancellationToken ct)
    {
        var ids = productIds.ToList();

        return await ReadQuery
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