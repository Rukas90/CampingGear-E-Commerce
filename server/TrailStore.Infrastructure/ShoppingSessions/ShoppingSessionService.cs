using TrailStore.Domain.Carts.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Errors;
using TrailStore.Domain.ShoppingSessions.Interfaces;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.ShoppingSessions;

[AppService<IShoppingSessionService>]
public class ShoppingSessionService(
    IShoppingSessionRepository sessionRepository, ICartItemRepository cartItemRepository) 
    : IShoppingSessionService
{
    private readonly TimeSpan ExpireTime = TimeSpan.FromDays(30);
    
    public async Task<ShoppingSession> GetOrCreateSession(ShoppingContext ctx, CancellationToken ct)
    {
        var result = await FindSession(ctx, ct);

        if (result.IsSuccess)
        {
            return result.Value;
        }
        
        return await CreateSession(customerId: null, ct);
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

    public async Task<ShoppingSession> CreateSession(Id<Customer>? customerId, CancellationToken ct)
        => await sessionRepository.CreateAsync(ShoppingSession.Create(customerId, ExpireTime), ct);

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

    public async Task ExtendSession(ShoppingSession session, CancellationToken ct)
    {
        if (session.CustomerId is not null)
        {
            return;
        }

        await sessionRepository.ExtendAsync(session.Id, ExpireTime, ct);
    }
}