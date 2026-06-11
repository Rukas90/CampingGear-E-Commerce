using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Payments.Models;

public class PaymentIntentCreateData
{
    public required Id<Order> OrderId { get; init; }
    public required decimal Amount { get; init; }
}