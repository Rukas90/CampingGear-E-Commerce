using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Checkout.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Checkout;

[AppService<ICheckoutSessionRepository>]
public class CheckoutSessionRepository(AppDbContext context) : ICheckoutSessionRepository
{
    public CheckoutSession Add(CheckoutSession checkoutSession)
    {
        context.CheckoutSessions.Add(checkoutSession);
        
        return checkoutSession;
    }

    public void Update(CheckoutSession checkoutSession)
    {
        context.CheckoutSessions.Update(checkoutSession);
    }
    
    public async Task<CheckoutSession?> FindByShoppingSessionIdAsync(Id<ShoppingSession> id, CancellationToken ct)
    {
        return await context.CheckoutSessions
            .Include(session => session.ShippingMethod)
            .FirstOrDefaultAsync(session => session.SessionId == id, ct);
    }

    public void Remove(CheckoutSession session)
    {
        context.CheckoutSessions.Remove(session);
    }
}