using Microsoft.Extensions.Options;
using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Infrastructure.Carts;

[AppService<ICartSessionService>]
public sealed class CartSessionService(
    ICartRepository cartRepository,
    IOptions<CartOptions> options) : ICartSessionService
{
    public async Task<Cart> FindOrCreateCart(Id<Cart>? cartId, Id<UserRef>? userId, CancellationToken ct)
    {
        var result = await FindCart(cartId, userId, ct);

        if (result.IsSuccess)
        {
            return result.Value;
        }
        
        return CreateCart(userId);
    }

    public async Task<Result<Cart>> FindCart(Id<Cart>? cartId, Id<UserRef>? userId, CancellationToken ct)
    {
        if (userId is not null)
        {
            var cart = await cartRepository.FindByUserId(userId.Value, ct);

            if (cart is not null)
            {
                return cart;
            }
        }
        
        if (cartId is not null)
        {
            var cart = await cartRepository.FindAsync(cartId.Value, ct);
            
            if (cart is not null)
            {
                return cart;
            }
        }

        return CartProblems.NotFound;
    }

    public async Task<Cart> FindOrCreateUserCart(Id<UserRef> userId, CancellationToken ct)
    {
        var session = await FindUserCart(userId, ct);

        if (session.IsSuccess)
        {
            return session.Value;
        }
            
        return CreateCart(userId);
    }
    
    public async Task<Result<Cart>> FindUserCart(Id<UserRef> userId, CancellationToken ct)
    {
        var session = await cartRepository.FindByUserId(userId, ct);

        if (session is null)
        {
            return ShoppingSessionsProblems.SessionNotFound;
        }
            
        return session;
    }

    public Cart CreateCart(Id<UserRef>? userId)
        => cartRepository.Add(Cart.Create(userId, options.Value.ExpiryTime));
}