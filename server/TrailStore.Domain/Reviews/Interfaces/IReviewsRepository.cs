using System.Linq.Expressions;
using TrailStore.Domain.Reviews.Models;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Reviews.Interfaces;

public interface IReviewsRepository
{
    Task<List<TResult>> ListAsync<TResult>(ReviewsQuery query,
        Expression<Func<Review, TResult>> selector, CancellationToken ct);
}