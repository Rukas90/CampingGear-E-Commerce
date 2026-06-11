using TrailStore.Domain.Checkout.Enums;
using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class CheckoutSession : IModel<CheckoutSession>, IEntityCreatable, IEntityUpdateable, IEntityExpirable
{
    public required Id<CheckoutSession> Id { get; init; }
    public required Id<ShoppingSession> SessionId { get; init; }
    
    public required CheckoutStatus Status { get; set; }
    public string? EmailAddress { get; set; }
    
    public PostalAddress? ShippingAddress { get; set; }
    public PostalAddress? BillingAddress { get; set; }
    public required bool ShippingAddressAsBillingAddress { get; set; }
    
    public Id<ShippingMethod>? ShippingMethodId { get; set; }
    
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public required DateTime ExpiresAt { get; set; }

    public ShippingMethod? ShippingMethod { get; private set; } = null;
    
    public static CheckoutSession Create(Id<ShoppingSession> sessionId, TimeSpan expireTime)
        => new()
        {
            Id = Id<CheckoutSession>.New(),
            SessionId = sessionId,
            Status = CheckoutStatus.Form,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.Today.Add(expireTime),
            ShippingAddressAsBillingAddress = true
        };
    
}