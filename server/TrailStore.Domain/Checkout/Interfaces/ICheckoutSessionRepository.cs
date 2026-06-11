using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Checkout.Interfaces;

public interface ICheckoutSessionRepository
{
    CheckoutSession Add(CheckoutSession checkoutSession);
    
    void Update(CheckoutSession checkoutSession);
    
    Task<CheckoutSession?> FindByShoppingSessionIdAsync(Id<ShoppingSession> id, CancellationToken ct);

    void Remove(CheckoutSession session);
}