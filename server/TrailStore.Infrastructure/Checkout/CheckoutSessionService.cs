using TrailStore.Domain.Carts.Interfaces;
using TrailStore.Domain.Checkout.Errors;
using TrailStore.Domain.Checkout.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Interfaces;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Checkout;

[AppService<ICheckoutSessionService>]
public class CheckoutSessionService(
    IShoppingSessionService shoppingSessionService,
    ICartItemRepository cartItemRepository,
    ICheckoutSessionRepository checkoutSessionRepository) 
    : ICheckoutSessionService
{
    public async Task<Result<CheckoutSession>> 
        GetCreateCheckoutSession(ShoppingContext ctx, CancellationToken ct)
    {
        var result = await FindCheckoutSession(ctx, ct);
        
        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var (checkoutSession, shoppingSession) = result.Value;

        if (checkoutSession is not null)
        {
            return checkoutSession;
        }
        
        var newCheckoutSession = await checkoutSessionRepository.CreateAsync(
            CheckoutSession.Create(shoppingSession.Id), ct);

        return newCheckoutSession;
    }

    public async Task<Result<(CheckoutSession? checkoutSession, ShoppingSession shoppingSession)>> 
        FindCheckoutSession(ShoppingContext ctx, CancellationToken ct)
    {
        var shoppingSessionResult = await shoppingSessionService.FindSession(ctx, ct);

        if (!shoppingSessionResult.IsSuccess)
        {
            return CheckoutProblems.NoSession;
        }
        
        var shoppingSession = shoppingSessionResult.Value;
        
        var cartCount = await cartItemRepository.CountBySessionAsync(shoppingSession.Id, ct);

        if (cartCount <= 0)
        {
            return CheckoutProblems.EmptyCart; 
        }
        
        var checkoutSession = await checkoutSessionRepository.FindByShoppingSessionIdAsync(shoppingSession.Id, ct);

        if (checkoutSession is not null)
        {
            return (checkoutSession, shoppingSession);
        }
        
        return (null, shoppingSession);
    }
}