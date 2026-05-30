using TrailStore.Domain.Payments.Enums;
using TrailStore.Domain.Shared.Enums;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Payment : IModel<Payment>
{
    public required Id<Payment> Id { get; init; }
    public required Id<Order> OrderId { get; init; }
    public required string IntentId { get; init; }
    public required decimal Amount { get; init; }
    public required string Currency { get; init; }
    public required PaymentStatus Status { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime UpdatedStatusAt { get; init; }

    public Order Order { get; private set; } = null!;
}