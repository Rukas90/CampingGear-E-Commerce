using Microsoft.Extensions.Options;
using TrailStore.Domain.Carts.Interfaces;
using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Errors;
using TrailStore.Domain.ShoppingSessions.Interfaces;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.ShoppingSessions;

[AppService<IShoppingSessionService>]
public class ShoppingSessionService(
    IShoppingSessionRepository sessionRepository, 
    ICartItemRepository cartItemRepository, 
    IOptions<ShoppingSessionOptions> options,
    IUnitOfWork unitOfWork) 
    : IShoppingSessionService
{
    public async Task<ShoppingSession> FindOrCreateSession(ShoppingContext ctx, CancellationToken ct)
    {
        var result = await FindSession(ctx, ct);

        if (result.IsSuccess)
        {
            return result.Value;
        }
        
        var newSession = CreateSession(ctx.CustomerId);

        await unitOfWork.SaveAsync(ct);
        
        return newSession;
    }

    public async Task<Result<ShoppingSession>> FindSession(ShoppingContext ctx, CancellationToken ct)
    {
        if (ctx.CustomerId is not null)
        {
            var session = await sessionRepository.FindByCustomerIdAsync(ctx.CustomerId.Value, ct);

            if (session is null)
            {
                return ShoppingSessionsProblems.SessionNotFound;
            }
            
            return session;
        }

        if (ctx.SessionId is not null)
        {
            var session = await sessionRepository.FindByIdAsync(ctx.SessionId.Value, ct);
            
            if (session is null)
            {
                return ShoppingSessionsProblems.SessionNotFound;
            }
            
            return session;
        }

        return ShoppingSessionsProblems.SessionNotFound;
    }

    public ShoppingSession CreateSession(Id<Customer>? customerId)
        => sessionRepository.Add(ShoppingSession.Create(customerId, options.Value.ExpiryTime));

    public async Task<ShoppingSessionSummary> GetSessionSummary(ShoppingContext ctx, CancellationToken ct)
    {
        var result = await FindSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return ShoppingSessionSummary.Blank;
        }
        
        return new ShoppingSessionSummary(
            Id: result.Value.Id,
            CartCount: await cartItemRepository.CountBySessionAsync(result.Value.Id, ct),
            WishlistCount: 0);
    }
}