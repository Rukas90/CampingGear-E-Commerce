using TrailStore.Catalog.Application.Results;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews.Inputs;
using TrailStore.Catalog.Domain.Reviews.Problems;
using TrailStore.Catalog.Domain.Reviews.Repositories;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Application.Queries.GetReviews;

[AppService<GetReviewsQueryHandler>]
public sealed class GetReviewsQueryHandler(
    IProductsRepository productsRepository,
    IReviewRepository reviewRepository,
    IUserService userService)
    : IQueryHandler<GetReviewsQuery, ReviewResult[]>
{
    public async Task<Result<ReviewResult[]>> Handle(GetReviewsQuery query, CancellationToken ct)
    {
        var productId = await productsRepository.GetIdFromSlug(query.ProductSlug, ct);

        if (productId is null)
        {
            return ReviewProblems.ProductNotFound;
        }

        var filter = new ReviewsFilter
        {
            ProductId = productId.Value,
            StarFilter = query.StarFilter,
            SortBy = query.SortBy,
            Pagination = query.Pagination,
            Page = query.Page,
            PageSize = query.PageSize
        };

        var reviews = await reviewRepository.ListAsync(filter, ct);
        var userIds = reviews.Select(r => r.UserId).Distinct().ToArray();
        var profiles = await userService.GetUserProfilesAsync(userIds, ct);

        return reviews.Select(review =>
        {
            var profile = profiles.SingleOrDefault(profile => profile.Id == review.UserId);

            return new ReviewResult
            {
                Id = review.Id,
                CustomerFirstName = profile?.FirstName ?? "",
                CustomerLastName = profile?.LastName ?? "",
                Rating = review.Rating,
                CreatedAt = review.CreatedAt,
                Headline = review.Headline,
                Text = review.Text,
                Recommended = review.Recommended,
                Likes = review.Likes,
                Dislikes = review.Dislikes
            };
        }).ToArray();
    }
}