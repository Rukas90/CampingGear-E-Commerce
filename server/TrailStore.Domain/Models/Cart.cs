using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class Cart : IModel<Cart>
{
    public Id<Cart>              Id         { get; init; }
    public Id<Customer>          CustomerId { get; init; }
    
    public Customer                Customer  { get; private set; } = null!;
    public IReadOnlyList<CartItem> Items     { get; private set; } = null!;
}