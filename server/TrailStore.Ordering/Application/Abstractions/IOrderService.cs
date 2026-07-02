using TrailStore.Ordering.Domain.Orders;

namespace TrailStore.Ordering.Application.Abstractions;

public interface IOrderService
{
    Order CreateOrder(CreateOrderRequest request);
}