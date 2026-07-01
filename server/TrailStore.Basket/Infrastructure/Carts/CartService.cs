using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Basket.Infrastructure.Sessions;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Infrastructure.Carts;

[AppService<ICartService>]
internal sealed class CartService(
    ISkuService skuService,
    IShoppingSessionService shoppingSessionService) : ICartService
{
    public async Task<Result<CartValidationStatusResult>> GetCartValidationStatus(ShoppingContextRef ctx, CancellationToken ct)
    {
        var result = await FindAndValidateSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var session = result.Value;
        
        return new CartValidationStatusResult(
            Id<ShoppingSessionRef>.From(session.Id), 
            CartEmpty: session.CartItems.Count == 0);
    }

    public async Task<CartItemResult[]> GetCartItems(ShoppingContextRef ctx, CancellationToken ct)
    {
        var result = await FindAndValidateSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return [];
        }
        
        var session = result.Value;
        
        var skus = await skuService.GetSkusFromIds(
            session.CartItems.Select(item => item.SkuId).ToArray(), 
            ct);

        return session.CartItems
            .Where(item => skus.Any(sku => sku.Id == item.SkuId))
            .Select(item =>
            {
                var sku = skus.Single(sku => sku.Id == item.SkuId);

                return new CartItemResult
                {
                    SkuId = sku.Id,
                    SkuCode = sku.Code,
                    UnitPrice = sku.UnitPrice,
                    Quantity = item.Quantity
                };
            }).ToArray();
    }

    private async Task<Result<ShoppingSession>> FindAndValidateSession(
        ShoppingContextRef ctx, CancellationToken ct)
    {
        var result = await shoppingSessionService.FindSession(ctx.ToDomain(), ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var session = result.Value;

        if (session.IsExpired())
        {
            return ShoppingSessionsProblems.SessionExpired;
        }

        return result.Value;
    }
}