using TrailStore.Catalog.Application.Results;

namespace TrailStore.Catalog.Api.Endpoints.GetReviews;

public static class ReviewResponseMapper
{
    public static ReviewResponse[] ToResponses(this IEnumerable<ReviewResult> reviews)
        => reviews.Select(ToResponse).ToArray();
    
    public static ReviewResponse ToResponse(this ReviewResult review)
        => new()
        {
            Id = review.Id,
            CustomerFirstName = review.CustomerFirstName,
            CustomerLastName = review.CustomerLastName,
            Rating = review.Rating,
            CreatedAt = review.CreatedAt,
            Headline = review.Headline,
            Text = review.Text,
            Recommended = review.Recommended,
            Likes = review.Likes,
            Dislikes = review.Dislikes,
        };
}