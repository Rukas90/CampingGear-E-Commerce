using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Payments;

public class Payment : IModel<Payment>, IEntityCreatable, IEntityExpirable
{
    public required Id<Payment> Id { get; init; }
    public required Id<Order> OrderId { get; init; }
    public required string IntentId { get; init; }
    public required decimal Amount { get; init; }
    public required string CurrencyCode { get; init; }
    public PaymentStatus Status { get; private set; }
    public DateTime UpdatedStatusAt { get; private set; }
    
    public Order Order { get; private set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    
    public static Payment Create(Id<Order> orderId, string intentId, decimal amount)
        => new()
        {
            Id = Id<Payment>.New(),
            OrderId = orderId,
            IntentId = intentId,
            Amount = amount,
            CurrencyCode = "eur",
            Status = PaymentStatus.Pending,
            CreatedAt = DateTime.UtcNow,
            UpdatedStatusAt = DateTime.UtcNow
        };
    
    public void Revoke()
    {
        Status = PaymentStatus.Failed;
        UpdatedStatusAt = DateTime.UtcNow;
    }
}