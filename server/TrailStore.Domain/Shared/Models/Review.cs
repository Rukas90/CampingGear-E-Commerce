using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Review : IModel<Review>, IEntityCreatable, IEntityUpdateable
{
    public required Id<Review> Id { get; init; }
    public required Id<Customer> CustomerId { get; init; }
    public required Id<Product> ProductId { get; init; }
    public required int Rating { get; init; }
    public required string Headline { get; init; }
    public required string Text { get; init; }
    public bool Recommended { get; init; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Product Product { get; private set; } = null!;
    public Customer Customer { get; private set; } = null!;
    public ICollection<ReviewVote> Votes { get; init; } = [];
}