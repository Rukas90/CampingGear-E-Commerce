using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Checkout.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Checkout;

[AppService<ICheckoutSessionRepository>]
public class CheckoutSessionRepository(AppDbContext context) : ICheckoutSessionRepository
{
    public async Task<CheckoutSession?> FindByIdAsync(Id<CheckoutSession> id, CancellationToken ct)
    {
        return await context.CheckoutSessions.FirstOrDefaultAsync(session => session.Id == id, ct);
    }
    
    public async Task<CheckoutSession?> FindByShoppingSessionIdAsync(Id<ShoppingSession> id, CancellationToken ct)
    {
        return await context.CheckoutSessions.FirstOrDefaultAsync(session => session.SessionId == id, ct);
    }

    public async Task DeleteAsync(Id<CheckoutSession> id, CancellationToken ct)
    {
        await context.CheckoutSessions
            .Where(s => s.Id == id)
            .ExecuteDeleteAsync(ct);
    }

    public async Task<CheckoutSession> CreateAsync(CheckoutSession checkoutSession, CancellationToken ct)
    {
        await context.CheckoutSessions.AddAsync(checkoutSession, ct);
        await context.SaveChangesAsync(ct);
        
        return checkoutSession;
    }

    public async Task UpdateAsync(CheckoutSession checkoutSession, CancellationToken ct)
    {
        context.CheckoutSessions.Update(checkoutSession);
        await context.SaveChangesAsync(ct);
    }
}