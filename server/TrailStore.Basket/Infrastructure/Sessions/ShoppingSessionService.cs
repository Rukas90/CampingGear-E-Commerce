using Microsoft.Extensions.Options;
using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Infrastructure.Sessions;

[AppService<IShoppingSessionService>]
public sealed class ShoppingSessionService(
    IShoppingSessionRepository sessionRepository, IOptions<ShoppingSessionOptions> options) : IShoppingSessionService
{
    public async Task<ShoppingSession> FindOrCreateSession(ShoppingContext ctx, CancellationToken ct)
    {
        var result = await FindSession(ctx, ct);

        if (result.IsSuccess)
        {
            return result.Value;
        }
        
        return CreateSession(ctx.OwnerId);
    }

    public async Task<Result<ShoppingSession>> FindSession(ShoppingContext ctx, CancellationToken ct)
    {
        if (ctx.OwnerId is not null)
        {
            return await FindUserSession(ctx.OwnerId.Value, ct);
        }

        if (ctx.SessionId is not null)
        {
            var session = await sessionRepository.FindAsync(ctx.SessionId.Value, ct);
            
            if (session is null)
            {
                return ShoppingSessionsProblems.SessionNotFound;
            }
            
            return session;
        }

        return ShoppingSessionsProblems.SessionNotFound;
    }

    public async Task<ShoppingSession> FindOrCreateUserSession(Id<UserRef> userId, CancellationToken ct)
    {
        var session = await FindUserSession(userId, ct);

        if (session.IsSuccess)
        {
            return session.Value;
        }
            
        return CreateSession(userId);
    }
    
    private async Task<Result<ShoppingSession>> FindUserSession(Id<UserRef> userId, CancellationToken ct)
    {
        var session = await sessionRepository.FindByUserId(userId, ct);

        if (session is null)
        {
            return ShoppingSessionsProblems.SessionNotFound;
        }
            
        return session;
    }

    public ShoppingSession CreateSession(Id<UserRef>? userId)
        => sessionRepository.Add(ShoppingSession.Create(userId, options.Value.ExpiryTime));
}