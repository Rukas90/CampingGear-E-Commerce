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

    public ShoppingSession Add(ShoppingSession shoppingSession)
    {
        context.ShoppingSessions.Add(shoppingSession);
        
        return shoppingSession;
    }
}