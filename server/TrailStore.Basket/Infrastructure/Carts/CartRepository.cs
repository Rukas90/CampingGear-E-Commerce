using Microsoft.EntityFrameworkCore;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Basket.Infrastructure.Database;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Basket.Infrastructure.Carts;

[AppService<ICartRepository>]
public class CartRepository(BasketDbContext _context) 
    : AggregateRepository<Cart, BasketDbContext>(_context), ICartRepository
{
    public Task<Cart?> FindByUserId(Id<UserRef> userId, CancellationToken ct)
        => AggregateWriteQuery.SingleOrDefaultAsync(cart => cart.UserId == userId, ct);
    
    protected override IQueryable<Cart> BuildAggregateQuery(DbSet<Cart> set)
        => set.Include(cart => cart.Items);
}