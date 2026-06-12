using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Orders.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Orders;

[AppService<IOrderRepository>]
public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public Order Add(Order order)
    {
        context.Orders.Add(order);

        return order;
    }

    public Task<TResult?> FindByTokenAsync<TResult>(
        string token, Expression<Func<Order, TResult>> selector, CancellationToken ct)
        => context.Orders.Where(order => order.Token == token).Select(selector).FirstOrDefaultAsync(ct);
}