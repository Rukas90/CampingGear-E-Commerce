using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Cart : IModel<Cart>
{
    public required Id<Cart> Id { get; init; }
    public required Id<Customer> CustomerId { get; init; }

    public Customer Customer { get; private set; } = null!;
    public ICollection<CartItem> Items { get; private set; } = null!;
}