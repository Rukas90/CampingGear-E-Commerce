using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Checkout.Interfaces;

public interface ICheckoutSessionService
{
    Task<Result<CheckoutSession>>
        GetCreateCheckoutSession(ShoppingContext ctx, CancellationToken ct);
    
    Task<Result<(CheckoutSession? checkoutSession, ShoppingSession shoppingSession)>>
        FindCheckoutSession(ShoppingContext ctx, CancellationToken ct);
}