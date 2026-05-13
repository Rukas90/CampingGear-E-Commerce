using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class ReviewVote : IModel<ReviewVote>
{
    public Id<ReviewVote> Id { get; init; }
    public Id<Review> ReviewId { get; init; }
    public bool IsLike { get; init; }
    public DateTime CreatedAt { get; init; }

    public Review Review { get; private set; } = null!;
}