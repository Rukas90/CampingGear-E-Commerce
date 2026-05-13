using System.Linq.Expressions;
using TrailStore.Api.Reviews.Dto;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Api.Reviews.Mapping;

public static class ReviewMappingSelectors
{
    public static Expression<Func<Review, ReviewDto>> ToDto()
    {
        return review => new ReviewDto
        {
            Id = review.Id,
            CustomerFirstName = review.Customer.FirstName ?? "",
            CustomerLastName = review.Customer.LastName ?? "",
            Rating = review.Rating,
            CreatedAt = review.CreatedAt,
            Headline = review.Headline,
            Text = review.Text,
            Recommended = review.Recommended,
            Likes = review.Votes.Count(v => v.IsLike),
            Dislikes = review.Votes.Count(v => !v.IsLike)
        };
    }
}