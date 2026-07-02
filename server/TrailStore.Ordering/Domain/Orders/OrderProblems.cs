using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public static class OrderProblems
{
    public static Problem NotFound(Guid orderId)
        => new("Not found", "order.not_found", $"Order by id {orderId} was not found.");
    
    public static readonly Problem MaxPaymentAttempts 
        = new("Max payment attempts", "order.max_payment_attempts", "Reached max payment attempts.");
}