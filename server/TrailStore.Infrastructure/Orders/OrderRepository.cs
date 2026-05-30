using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Orders.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Orders;

[AppService<IOrderRepository>]
public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task<Order> CreateAsync(Order order, CancellationToken ct)
    {
        await context.AddAsync(order, ct);
        await context.SaveChangesAsync(ct);
        
        return order;
    }
}