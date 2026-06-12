using System.Linq.Expressions;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderRepository
{
    Order Add(Order order);
    
    Task<TResult?> FindByTokenAsync<TResult>(string token, Expression<Func<Order, TResult>> selector, CancellationToken ct);
}