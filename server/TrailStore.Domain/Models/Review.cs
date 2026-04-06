using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class Review : IModel<Review>
{
    public required Id<Review>  Id        { get; init; }
    public required Id<Customer>    UserId    { get; init; }
    public required Id<Product> ProductId { get; init; }
    public required DateTime    CreatedAt { get; init; }
    public required int         Rating    { get; init; }
    public required string      Headline  { get; init; }
    public required string      Text      { get; init; }
    public int                  Likes     { get; set; } = 0;
    public int                  Dislikes  { get; set; } = 0;
    
    public Customer    Customer    { get; private set; } = null!;
    public Product Product { get; private set; } = null!;
}