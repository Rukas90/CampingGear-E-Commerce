namespace TrailStore.Ordering.Domain.Orders;

public enum OrderStatus
{
    Confirmed,
    PaymentReceived,
    PaymentFailed,
    InProcess,
    Canceled,
    Refunded,
    Completed
}