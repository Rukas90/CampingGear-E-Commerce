using Microsoft.EntityFrameworkCore;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Infrastructure.Database;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Ordering.Infrastructure.Checkout;

[AppService<ICheckoutSessionRepository>]
public class CheckoutSessionRepository(OrderingDbContext _context) 
    : AggregateRepository<CheckoutSession, OrderingDbContext>(_context), ICheckoutSessionRepository
{
    public Task<CheckoutSession?> FindByShoppingSessionIdAsync(Id<ShoppingSessionRef> id, CancellationToken ct)
        => AggregateWriteQuery
            .FirstOrDefaultAsync(session => session.SessionId == id, ct);
}