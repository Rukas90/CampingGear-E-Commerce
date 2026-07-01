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
        var result = await TryFindCheckoutSession(ctx, ct);
        
        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var checkoutSession = result.Value;

        if (checkoutSession is not null)
        {
            return checkoutSession;
        }

        if (ctx.SessionId is null)
        {
            return CheckoutProblems.NoSession;
        }
        
        var newCheckoutSession = checkoutSessionRepository.Add(
            CheckoutSession.Create(ctx.SessionId.Value, ctx.OwnerId, 
                ctx.OwnerId is not null 
                ? options.Value.ExpiresForCustomer
                : options.Value.ExpiresForGuest));
        
        return newCheckoutSession;
    }

    public async Task<Result<CheckoutSession>> FindCheckoutSession(ShoppingContextRef ctx, CancellationToken ct)
    {
        var result = await TryFindCheckoutSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var checkoutSession = result.Value;

        if (checkoutSession is null)
        {
            return CheckoutProblems.NoSession;
        }
        
        return checkoutSession;
    }

    public async Task<Result<CheckoutSession?>> TryFindCheckoutSession(ShoppingContextRef ctx, CancellationToken ct)
    {
        if (ctx.SessionId is null && ctx.OwnerId is null)
        {
            return CheckoutProblems.NoSession;
        }

        CheckoutSession? checkoutSession = null;
        
        if (ctx.SessionId is not null)
        {
            var sessionId = ctx.SessionId.Value;
            
            checkoutSession = await checkoutSessionRepository.FindByShoppingSessionIdAsync(sessionId, ct);
        }

        if (checkoutSession is null && ctx.OwnerId is not null)
        {
            var userId = ctx.OwnerId.Value;
            
            checkoutSession = await checkoutSessionRepository.FindByUserIdAsync(userId, ct);
        }
        
        return checkoutSession;
    }

    public async Task<Result> ValidateSession(ShoppingContextRef ctx, CancellationToken ct)
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
        
        return Result.Ok();
    }
}