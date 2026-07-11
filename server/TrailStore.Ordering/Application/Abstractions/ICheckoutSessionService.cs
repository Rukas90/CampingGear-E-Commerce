using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Abstractions;

public interface ICheckoutSessionService
{
    Task<Result<CheckoutSession>> GetCreateCheckoutSession(Id<CartRef> cartId, Id<UserRef>? userId, CancellationToken ct);

    Task<Result<CheckoutSession>> FindCheckoutSession(Id<CartRef> cartId, CancellationToken ct);
}