using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Ordering.Infrastructure.Database;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Ordering.Infrastructure.Orders;

[AppService<IOrderRepository>]
public sealed class OrderRepository(OrderingDbContext _context) 
    : AggregateRepository<Order, OrderingDbContext>(_context), IOrderRepository
{
    public Task<Order?> FindByTokenAsync(string token, CancellationToken ct)
        => AggregateWriteQuery.SingleOrDefaultAsync(order => order.Token == token, ct);

    public Task<Order[]> GetUserOrdersAsync(Id<UserRef> userId, CancellationToken ct)
        => AggregateReadQuery.Where(order => order.UserId == userId).ToArrayAsync(ct);

    protected override IQueryable<Order> BuildAggregateQuery(DbSet<Order> set)
        => set
            .Include(order => order.Items)
            .Include(order => order.Shipping);
}