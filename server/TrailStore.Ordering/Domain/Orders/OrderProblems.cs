using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public static class OrderProblems
{
    public static readonly Problem MaxPaymentAttempts 
        = new ("Max payment attempts", "order.max_payment_attempts", "Reached max payment attempts.");
}