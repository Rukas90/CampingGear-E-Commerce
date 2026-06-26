using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Reviews.Models;

public class ReviewVote : IModel<ReviewVote>, IEntityCreatable
{
    public Id<ReviewVote> Id { get; init; }
    public Id<Review> ReviewId { get; init; }
    public bool IsLike { get; init; }
    
    public DateTime CreatedAt { get; set; }

    public Review Review { get; private set; } = null!;
}