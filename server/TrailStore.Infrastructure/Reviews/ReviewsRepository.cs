using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Reviews.Interfaces;
using TrailStore.Domain.Reviews.Models;
using TrailStore.Domain.Reviews.Specifications;
using TrailStore.Domain.Shared.Enums;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Reviews;

[AppService<IReviewsRepository>]
public sealed class ReviewsRepository(AppDbContext context) : IReviewsRepository
{
    public async Task<List<TResult>> ListAsync<TResult>(ReviewsQuery query, Expression<Func<Review, TResult>> selector,
        CancellationToken ct)
    {
        var queryable = context.Reviews.AsQueryable();

        var specification = ReviewsSpecificationBuilder.Build(query);

        queryable = queryable.Where(specification.ToExpression());
        queryable = GetOrderedQueryable(queryable, query.SortBy);

        queryable = query.Pagination
            ? queryable.Skip(query.Page * query.PageSize).Take(query.PageSize)
            : queryable;

        return await queryable
            .Select(selector)
            .ToListAsync(ct);
    }

    private static IQueryable<Review> GetOrderedQueryable(IQueryable<Review> query, ReviewsSortBy sortBy)
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
}