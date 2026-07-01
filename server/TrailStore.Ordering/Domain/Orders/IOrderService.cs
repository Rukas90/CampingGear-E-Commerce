namespace TrailStore.Ordering.Domain.Orders;

public interface IOrderService
{
    Order CreateOrder(CreateOrderRequest request);
}