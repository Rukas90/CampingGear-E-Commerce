using TrailStore.Basket.Contracts.Session;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Abstractions;

public interface ICheckoutSessionService
{
    Task<Result<CheckoutSession>>
        GetCreateCheckoutSession(ShoppingContextRef ctx, CancellationToken ct);

    Task<Result<CheckoutSession>>
        FindCheckoutSession(ShoppingContextRef ctx, CancellationToken ct);

    Task<Result> ValidateSession(ShoppingContextRef ctx, CancellationToken ct);
}