using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Contracts.Carts;

public interface ICartService
{
    Task<Result<CartValidationStatusResult>> GetCartValidationStatus(
        ShoppingContextRef ctx, CancellationToken ct);
    
    Task<CartItemResult[]> GetCartItems(ShoppingContextRef ctx, CancellationToken ct);
    
    Task<Result<ShoppingContextRef>> MergeCart(ShoppingContextRef guestCtx, Id<UserRef> userId, CancellationToken ct);
}