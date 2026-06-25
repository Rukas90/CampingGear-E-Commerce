using Microsoft.EntityFrameworkCore;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Basket.Infrastructure.Database;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Basket.Infrastructure.Sessions;

[AppService<IShoppingSessionRepository>]
public class ShoppingSessionRepository(BasketDbContext _context) 
    : AggregateRepository<ShoppingSession, BasketDbContext>(_context), IShoppingSessionRepository
{
    public Task<ShoppingSession?> FindByUserId(Id<UserRef> userId, CancellationToken ct)
        => AggregateWriteQuery.SingleOrDefaultAsync(session => session.UserId == userId, ct);
    
    protected override IQueryable<ShoppingSession> BuildAggregateQuery(DbSet<ShoppingSession> set)
        => set.Include(session => session.CartItems);
}