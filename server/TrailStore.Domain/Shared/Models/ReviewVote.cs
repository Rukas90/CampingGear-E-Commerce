using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class ReviewVote : IModel<ReviewVote>, IEntityCreatable
{
    public Id<ReviewVote> Id { get; init; }
    public Id<Review> ReviewId { get; init; }
    public bool IsLike { get; init; }
    
    public DateTime CreatedAt { get; set; }

    public Review Review { get; private set; } = null!;
}