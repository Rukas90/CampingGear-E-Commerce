using TrailStore.Basket.Domain.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Abstractions;

public interface ICartSessionService
{
    Task<Cart> FindOrCreateCart(Id<Cart>? cartId, Id<UserRef>? userId, CancellationToken ct);    
    
    Task<Result<Cart>> FindCart(Id<Cart>? cartId, Id<UserRef>? userId, CancellationToken ct);

    Task<Cart> FindOrCreateUserCart(Id<UserRef> userId, CancellationToken ct);

    Task<Result<Cart>> FindUserCart(Id<UserRef> userId, CancellationToken ct);

    Cart CreateCart(Id<UserRef>? userId);
}