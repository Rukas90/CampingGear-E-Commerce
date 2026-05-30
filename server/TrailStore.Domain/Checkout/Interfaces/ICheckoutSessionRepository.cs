using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Checkout.Interfaces;

public interface ICheckoutSessionRepository
{
    Task<CheckoutSession?> FindByIdAsync(Id<CheckoutSession> id, CancellationToken ct);

    Task<CheckoutSession?> FindByShoppingSessionIdAsync(Id<ShoppingSession> id, CancellationToken ct);

    Task DeleteAsync(Id<CheckoutSession> id, CancellationToken ct);
    
    Task<CheckoutSession> CreateAsync(CheckoutSession checkoutSession, CancellationToken ct);
    
    Task UpdateAsync(CheckoutSession checkoutSession, CancellationToken ct);
}