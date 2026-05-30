using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Cart : IModel<Cart>
{
    public required Id<Cart> Id { get; init; }
    
    public ICollection<CartItem> Items { get; private set; } = null!;
}