using TrailStore.Catalog.Domain.Reviews.Models;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Api.Endpoints.GetReviews;

public sealed class ReviewResponse
{
    public required Id<Review> Id { get; init; }
    public required string CustomerFirstName { get; init; }
    public required string CustomerLastName { get; init; }
    public required int Rating { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required string Headline { get; init; }
    public required string Text { get; init; }
    public required bool Recommended { get; init; }
    public required int Likes { get; init; }
    public required int Dislikes { get; init; }
}