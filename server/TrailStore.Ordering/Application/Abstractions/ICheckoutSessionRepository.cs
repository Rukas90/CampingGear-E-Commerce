using TrailStore.Basket.Contracts.Carts;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Abstractions;

public interface ICheckoutSessionRepository : IAggregateRepository<CheckoutSession>
{
    Task<CheckoutSession?> FindByCartIdAsync(Id<CartRef> cartId, CancellationToken ct);
}