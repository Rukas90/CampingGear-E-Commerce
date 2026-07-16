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
    ISavedCheckoutDetailsRepository savedCheckoutDetailsRepository,
    IUserService userService,
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

        var result = await CreateCheckoutSession(cartId, userId, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var newCheckoutSession = result.Value;
        
        checkoutSessionRepository.Add(newCheckoutSession);
        
        return newCheckoutSession;
    }

    private async Task<Result<CheckoutSession>> CreateCheckoutSession(
        Id<CartRef> cartId, Id<UserRef>? userId, CancellationToken ct)
    {
        var expireTime = userId is not null
            ? options.Value.ExpiresForCustomer
            : options.Value.ExpiresForGuest;

        var newCheckoutSession = CheckoutSession.Create(cartId, expireTime);

        if (userId is null)
        {
            return newCheckoutSession;
        }
        
        var profile = await userService.GetUserProfileAsync(userId.Value, ct);

        if (profile is null)
        {
            return CheckoutProblems.UserNotFound;
        }
            
        var result = newCheckoutSession.AssignUser(userId.Value, profile.EmailAddress);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var savedDetails = await savedCheckoutDetailsRepository.FindByUserIdAsync(userId.Value, ct);

        if (savedDetails is not null)
        {
            newCheckoutSession.Fill(savedDetails);
        }
        
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