using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Abstractions;

public interface ICheckoutSessionRepository : IAggregateRepository<CheckoutSession>
{
    Task<CheckoutSession?> FindByShoppingSessionIdAsync(Id<ShoppingSessionRef> id, CancellationToken ct);
    
    Task<CheckoutSession?> FindByUserIdAsync(Id<UserRef> id, CancellationToken ct);
}