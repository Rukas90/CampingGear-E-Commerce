using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Infrastructure.Carts;

[AppService<ICartService>]
internal sealed class CartService(
    ISkuService skuService,
    IBasketUnitOfWork unitOfWork,
    ICartRepository cartRepository, 
    ICartSessionService cartSessionService) : ICartService
{
    public async Task<Result<CartValidationStatusResult>> GetCartValidationStatus(CartSessionContextRef ctx, CancellationToken ct)
    {
        var result = await cartSessionService.FindCart(Id.Convert<CartRef, Cart>(ctx.CartId), userId: ctx.UserId, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var cart = result.Value;
        
        return new CartValidationStatusResult(CartEmpty: cart.Items.Count == 0);
    }

    public async Task<CartResult?> GetCart(Id<CartRef> cartId, CancellationToken ct)
    {
        var cart = await cartRepository.FindAsync(Id.Convert<CartRef, Cart>(cartId), ct);

        if (cart is null)
        {
            return null;
        }
        
        var skus = await skuService.GetSkusFromIds(
            cart.Items.Select(item => item.SkuId).ToArray(), 
            ct);

        return new CartResult(cartId, cart.UserId, cart.Items
            .Where(item => skus.Any(sku => sku.Id == item.SkuId))
            .Select(item =>
            {
                var sku = skus.Single(sku => sku.Id == item.SkuId);

                return new CartItemResult
                {
                    SkuId = sku.Id,
                    BrandName = sku.Brand.Name,
                    ProductName = sku.Product.Name,
                    VariantLine = sku.VariantLine,
                    UnitPrice = sku.UnitPrice,
                    Quantity = item.Quantity,
                    ThumbnailUrl = sku.ThumbnailUrl
                };
            }).ToArray());
    }

    /// <summary>
    /// Merges guest cart with the user cart.
    /// </summary>
    /// <returns>User cart id.</returns>
    public async Task<Result<Id<CartRef>>> MergeCart(
        Id<CartRef>? guestCartId, Id<UserRef> userId, CancellationToken ct)
    {
        if (guestCartId is null)
        {
            return CartProblems.NotFound;
        }
        
        var result = await cartSessionService.FindCart(
            Id.Convert<CartRef, Cart>(guestCartId), userId: null, ct);
        
        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var guestCart = result.Value;
        
        var userCart = await cartSessionService.FindOrCreateUserCart(userId, ct);
        
        userCart.MergeWith(guestCart);
        cartRepository.Delete(guestCart);
        
        await unitOfWork.SaveAsync(ct);

        return Id<CartRef>.From(userCart.Id);
    }
}