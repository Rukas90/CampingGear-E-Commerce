namespace TrailStore.Domain.Orders.Enums;

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