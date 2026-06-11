using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderRepository
{
    Order Add(Order order);
}