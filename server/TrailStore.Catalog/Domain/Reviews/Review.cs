using TrailStore.Catalog.Domain.Products;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Reviews;

public class Review : AggregateRoot<Review>, IEntityCreatable, IEntityUpdateable
{
    public required Id<Product> ProductId { get; init; }
    public required Guid UserId { get; init; }
    public required int Rating { get; init; }
    public required string Headline { get; init; }
    public required string Text { get; init; }
    public bool Recommended { get; init; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<ReviewVote> Votes { get; init; } = [];
}