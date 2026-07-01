using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Checkout;

public class CheckoutSession : AggregateRoot<CheckoutSession>, IEntityCreatable, IEntityUpdateable, IEntityExpirable
{
    public required Id<ShoppingSessionRef> SessionId { get; init; }
    public Id<UserRef>? UserId { get; init; }
    
    public required CheckoutStatus Status { get; set; }
    public string? EmailAddress { get; set; }
    
    public ShippingAddress? ShippingAddress { get; set; }
    public BillingAddress? BillingAddress { get; set; }
    public required bool ShippingAddressAsBillingAddress { get; set; }
    
    public Id<ShippingMethod>? ShippingMethodId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    
    public static CheckoutSession Create(Id<ShoppingSessionRef> sessionId, Id<UserRef>? userId, TimeSpan expireTime)
        => new()
        {
            Id = Id<CheckoutSession>.New(),
            UserId = userId,
            SessionId = sessionId,
            Status = CheckoutStatus.Form,
            ExpiresAt = DateTime.UtcNow.Add(expireTime),
            ShippingAddressAsBillingAddress = true
        };
    
}