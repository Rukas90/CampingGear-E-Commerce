using TrailStore.Basket.Contracts.Session;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Contracts.Carts;

public interface ICartService
{
    Task<Result<CartValidationStatusResult>> GetCartValidationStatus(
        ShoppingContextRef ctx, CancellationToken ct);
    
    Task<Result<decimal>> CalculateSubtotal(ShoppingContextRef ctx, CancellationToken ct);
}