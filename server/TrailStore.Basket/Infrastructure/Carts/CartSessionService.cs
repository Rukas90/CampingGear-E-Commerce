using Microsoft.Extensions.Options;
using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
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
        Console.WriteLine("CartId: " + cartId?.Value ?? "Null");
        Console.WriteLine("UserId: " + userId?.Value ?? "Null");
        
        if (cartId is null)
        {
            if (userId is not null)
            {
                return await FindUserCart(userId.Value, ct);
            }
            
            Console.WriteLine("No cart found");
            
            return CartProblems.NotFound;
        }
        
        var cart = await cartRepository.FindAsync(cartId.Value, ct);
        
        if (cart is null || cart.UserId != userId)
        {
            Console.WriteLine("Cart found but user ids do not match");
            
            Console.WriteLine("cart.UserId: " + cart!.UserId);
            Console.WriteLine("userId: " + userId);
            
            return CartProblems.NotFound;
        }
        
        Console.WriteLine("Cart found");
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