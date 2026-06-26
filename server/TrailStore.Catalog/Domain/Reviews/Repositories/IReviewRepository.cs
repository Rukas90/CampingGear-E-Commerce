using System.Linq.Expressions;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews.Inputs;
using TrailStore.Catalog.Domain.Reviews.Models;
using TrailStore.Catalog.Domain.Reviews.Projections;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Reviews.Repositories;

public interface IReviewRepository : IAggregateRepository<Review>
{
    Task<List<Review>> ListAsync(ReviewsFilter filter, CancellationToken ct);
    
    Task<List<Review>> ListAsync(Id<Product> productId, CancellationToken ct);
    
    Task<ReviewsSummary[]> GetReviewsSummariesAsync(
        IEnumerable<Id<Product>> productIds, CancellationToken ct);
}