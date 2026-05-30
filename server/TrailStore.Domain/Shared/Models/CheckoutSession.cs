using TrailStore.Domain.Checkout.Enums;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class CheckoutSession : IModel<CheckoutSession>
{
    public required Id<CheckoutSession> Id { get; init; }
    public required Id<ShoppingSession> SessionId { get; init; }
    
    public required CheckoutStatus Status { get; set; }
    public string? EmailAddress { get; set; }
    
    public PostalAddress? ShippingAddress { get; set; }
    public PostalAddress? BillingAddress { get; set; }
    public required bool ShippingAddressAsBillingAddress { get; set; }
    
    public required DateTime CreatedAt { get; init; }
    
    public static CheckoutSession Create(Id<ShoppingSession> sessionId)
        => new()
        {
            Id = Id<CheckoutSession>.New(),
            SessionId = sessionId,
            Status = CheckoutStatus.Form,
            CreatedAt = DateTime.UtcNow,
            ShippingAddressAsBillingAddress = true
        };
}