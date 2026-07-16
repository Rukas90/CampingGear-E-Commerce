using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public static class OrderProblems
{
    public static Problem NotFound(Guid id)
        => new("Not found", "order.not_found", $"Order by id {id} was not found.");
    
    public static Problem PaymentNotFound(string intentId)
        => new("Payment not found", "order.payment_not_found", $"Order payment by the intent id {intentId} is not found.");
    
    public static Problem CannotCancel(OrderStatus status)
        => new("Cannot cancel order", "order.cannot_cancel", $"Orders in '{status}' status cannot be cancelled.");
    
    public static Problem NonPendingOrderPayment
        => new("Cannot issue payment", "order.not_pending", "Payment can only be issued while the order is pending.");
    
    public static readonly Problem NonPendingOrderConfirmation
        = new("Cannot confirm order", "order.confirm", "Cannot confirm a non pending order.");
    
    public static Problem MaxPaymentAttempts
        => new("Payment attempts exhausted", "order.max_payment_attempts", "This order has reached its maximum number of payment attempts.");
    
    public static Problem OrderAlreadyFinalized(OrderStatus status)
        => new("Order already finalized", "order.already_finalized", $"Order is in a terminal status ('{status}') and cannot be changed.");
}