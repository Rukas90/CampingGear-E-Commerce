using Microsoft.Extensions.Options;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Infrastructure.Checkout;

[AppService<ICheckoutSessionService>]
public class CheckoutSessionService(
    ICheckoutSessionRepository checkoutSessionRepository,
    IOptions<CheckoutSessionOptions> options) 
    : ICheckoutSessionService
{
    public async Task<Result<CheckoutSession>> 
        GetCreateCheckoutSession(Id<CartRef> cartId, Id<UserRef>? userId, CancellationToken ct)
    {
        var checkoutSession = await checkoutSessionRepository.FindByCartIdAsync(cartId, ct);

        if (checkoutSession is not null)
        {
            return checkoutSession;
        }
        
        var newCheckoutSession = checkoutSessionRepository.Add(
            CheckoutSession.Create(cartId, 
                userId is not null 
                ? options.Value.ExpiresForCustomer
                : options.Value.ExpiresForGuest));
        
        return newCheckoutSession;
    }

    public async Task<Result<CheckoutSession>> FindCheckoutSession(Id<CartRef> cartId, CancellationToken ct)
    {
        var checkoutSession = await checkoutSessionRepository.FindByCartIdAsync(cartId, ct);
        
        if (checkoutSession is null)
        {
            return CheckoutProblems.NoSession;
        }
        
        return checkoutSession;
    }
}