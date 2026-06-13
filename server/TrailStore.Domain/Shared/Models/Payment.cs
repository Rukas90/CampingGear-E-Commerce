using TrailStore.Domain.Payments.Enums;
using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Payment : IModel<Payment>, IEntityCreatable, IEntityExpirable
{
    public required Id<Payment> Id { get; init; }
    public required Id<Order> OrderId { get; init; }
    public required string IntentId { get; init; }
    public required decimal Amount { get; init; }
    public required string CurrencyCode { get; init; }
    public required PaymentStatus Status { get; init; }
    public required DateTime UpdatedStatusAt { get; init; }

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
            UpdatedStatusAt =  DateTime.UtcNow
        };
    
}