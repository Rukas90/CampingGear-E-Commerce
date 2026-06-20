using TrailStore.Catalog.Domain.Products;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Reviews;

public interface IReviewRepository : IAggregateRepository<Review>
{
    Task<List<Review>> ListAsync(Id<Product> productId, CancellationToken ct);
    
    Task<ReviewsSummary[]> GetReviewsSummariesAsync(
        IEnumerable<Id<Product>> productIds, CancellationToken ct);
}