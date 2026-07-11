using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Contracts.Carts;

public interface ICartService
{
    Task<Result<CartValidationStatusResult>> GetCartValidationStatus(CartSessionContextRef ctx, CancellationToken ct);
    
    Task<CartResult?> GetCart(Id<CartRef> cartId, CancellationToken ct);
    
    Task<Result<Id<CartRef>>> MergeCart(Id<CartRef>? guestCartId, Id<UserRef> userId, CancellationToken ct);
}