using Microsoft.Extensions.Options;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Infrastructure.Checkout;

[AppService<ICheckoutSessionService>]
public class CheckoutSessionService(
    ICartService cartService,
    ICheckoutSessionRepository checkoutSessionRepository,
    IOptions<CheckoutSessionOptions> options) 
    : ICheckoutSessionService
{
    public async Task<Result<CheckoutSession>> 
        GetCreateCheckoutSession(ShoppingContextRef ctx, CancellationToken ct)
    {
        var result = await FindCheckoutSession(ctx, ct);
        
        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var (checkoutSession, shoppingSessionId) = result.Value;

        if (checkoutSession is not null)
        {
            return checkoutSession;
        }
        
        var newCheckoutSession = checkoutSessionRepository.Add(
            CheckoutSession.Create(shoppingSessionId, ctx.OwnerId is not null 
                ? options.Value.ExpiresForCustomer
                : options.Value.ExpiresForGuest));
        
        return newCheckoutSession;
    }

    public async Task<Result<(CheckoutSession? checkoutSession, Id<ShoppingSessionRef> shoppingSessionId)>> 
        FindCheckoutSession(ShoppingContextRef ctx, CancellationToken ct)
    {
        var result = await cartService.GetCartValidationStatus(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var status = result.Value;

        if (status.CartEmpty)
        {
            return CheckoutProblems.EmptyCart;
        }
        
        var checkoutSession = await checkoutSessionRepository.FindByShoppingSessionIdAsync(status.SessionId, ct);

        if (checkoutSession is not null)
        {
            return (checkoutSession, status.SessionId);
        }
        
        return (null, status.SessionId);
    }
}