using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Checkout.Interfaces;

public interface ICheckoutSessionService
{
    Task<Result<CheckoutSession>>
        GetCreateCheckoutSession(ShoppingContext ctx, CancellationToken ct);
}