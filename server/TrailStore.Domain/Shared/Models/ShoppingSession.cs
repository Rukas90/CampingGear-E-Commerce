using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class ShoppingSession : IModel<ShoppingSession>, IEntityCreatable, IEntityExpirable
{
    public required Id<ShoppingSession> Id { get; init; }
    
    public Id<Customer>? CustomerId { get; init; }
    
    public Customer Customer { get; private set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }

    public ICollection<CartItem> CartItems { get; private set; } = null!;

    public static ShoppingSession Create(Id<Customer>? customerId, TimeSpan expireTime)
        => new()
        {
            Id = Id<ShoppingSession>.New(),
            ExpiresAt = customerId == null ? DateTime.UtcNow.Add(expireTime) : null,
            CustomerId = customerId,
        };
    
    public void Extend(TimeSpan duration)
    {
        if (CustomerId != null) return;
        
        ExpiresAt = DateTime.UtcNow.Add(duration);
    }
}