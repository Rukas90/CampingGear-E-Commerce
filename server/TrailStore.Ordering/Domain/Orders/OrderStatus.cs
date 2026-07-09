namespace TrailStore.Ordering.Domain.Orders;

public enum OrderStatus
{
    Pending,
    OnHold,
    Processing,
    Failed,
    Canceled,
    Completed,
}