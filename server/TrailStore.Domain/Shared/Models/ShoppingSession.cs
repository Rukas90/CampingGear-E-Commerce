using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class ShoppingSession : IModel<ShoppingSession>
{
    public required Id<ShoppingSession> Id { get; init; }
    
    public Id<Customer>? CustomerId { get; init; }
    
    public DateTime CreatedAt { get; init; }
    
    public DateTime? ExpiresAt { get; set; }
    
    public Customer Customer { get; private set; } = null!;

    public ICollection<CartItem> CartItems { get; private set; } = null!;
    
    public static ShoppingSession Create(Id<Customer>? customerId, TimeSpan expireTime)
        => new()
        {
            Id = Id<ShoppingSession>.New(),
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = customerId != null ? null : DateTime.UtcNow.Add(expireTime),
            CustomerId = customerId,
        };

    public void Extend(TimeSpan expireTime)
    {
        if (CustomerId is not null)
        {
            return;
        }
        
        ExpiresAt = DateTime.UtcNow.Add(expireTime);
    }
}