using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Interfaces;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.ShoppingSessions;

[AppService<IShoppingSessionRepository>]
public class ShoppingSessionRepository(AppDbContext context) : IShoppingSessionRepository
{
    public async Task<ShoppingSession?> FindByIdAsync(Id<ShoppingSession> id, CancellationToken ct)
    {
        return await context.ShoppingSessions.FirstOrDefaultAsync(session => session.Id == id, ct);
    }

    public async Task<ShoppingSession?> FindByCustomerIdAsync(Id<Customer> id, CancellationToken ct)
    {
        return await context.ShoppingSessions.FirstOrDefaultAsync(session => session.CustomerId == id, ct);
    }

    public async Task<ShoppingSession> CreateAsync(ShoppingSession shoppingSession, CancellationToken ct)
    {
        await context.ShoppingSessions.AddAsync(shoppingSession, ct);
        await context.SaveChangesAsync(ct);
        
        return shoppingSession;
    }

    public async Task ExtendAsync(Id<ShoppingSession> id, TimeSpan expireTime, CancellationToken ct)
    {
        await context.ShoppingSessions
            .Where(s => s.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(x => x.ExpiresAt, DateTime.UtcNow.Add(expireTime)), ct);
    }
}