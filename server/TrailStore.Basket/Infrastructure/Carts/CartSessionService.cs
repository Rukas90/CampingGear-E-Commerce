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
        if (cartId is null)
        {
            if (userId is not null)
            {
                return await FindUserCart(userId.Value, ct);
            }
            
            return CartProblems.NotFound;
        }
        
        var cart = await cartRepository.FindAsync(cartId.Value, ct);
        
        if (cart is null || cart.UserId is not null && cart.UserId != userId)
        {
            return CartProblems.NotFound;
        }
        
        return cart;
    }

    public async Task<Cart> FindOrCreateUserCart(Id<UserRef> userId, CancellationToken ct)
    {
        var result = await FindUserCart(userId, ct);

        if (result.IsSuccess)
        {
            return result.Value;
        }
            
        return CreateCart(userId);
    }
    
    public async Task<Result<Cart>> FindUserCart(Id<UserRef> userId, CancellationToken ct)
    {
        var cart = await cartRepository.FindByUserId(userId, ct);

        if (cart is null)
        {
            return CartProblems.NotFound;
        }
            
        return cart;
    }

    public Cart CreateCart(Id<UserRef>? userId)
        => cartRepository.Add(Cart.Create(userId, options.Value.ExpiryTime));
}