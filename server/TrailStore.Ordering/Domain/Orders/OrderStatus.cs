namespace TrailStore.Ordering.Domain.Orders;

public enum OrderStatus
{
    Created,
    AwaitingPayment,
    PaymentReceived,
    PaymentFailed,
    InProcess,
    Canceled,
    Refunded,
    Completed
}