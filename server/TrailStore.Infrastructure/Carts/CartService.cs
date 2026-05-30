using System.Linq.Expressions;
using TrailStore.Domain.Carts.Errors;
using TrailStore.Domain.Carts.Interfaces;
using TrailStore.Domain.Carts.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Interfaces;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Domain.Skus.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Carts;

[AppService<ICartService>]
public class CartService(
    IShoppingSessionService shoppingSessionService,
    ISkuRepository skuRepository,
    ICartItemRepository cartItemRepository) : ICartService
{
    public async Task<Result<Id<ShoppingSession>>> AddItemToCart(
        CartLineItem lineItem, ShoppingContext ctx, CancellationToken ct)
    {
        var session = await shoppingSessionService.GetOrCreateSession(ctx, ct);

        var result = await AddItemQuantity(
            session.Id, lineItem.Code, lineItem.Quantity, ct);
        
        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        await shoppingSessionService.ExtendSession(session, ct);
        
        return session.Id;
    }
    
    public async Task<Result<Id<ShoppingSession>>> RemoveItemFromCart(
        string code, ShoppingContext ctx, CancellationToken ct)
    {
        var result = await shoppingSessionService.FindSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var session = result.Value;
        
        await cartItemRepository.DeleteBySessionAndCodeAsync(session.Id, code, ct);
        await shoppingSessionService.ExtendSession(session, ct);
        
        return session.Id;
    }

    public async Task<Result<Id<ShoppingSession>>> EmptyCart(ShoppingContext ctx, CancellationToken ct)
    {
        var sessionResult = await shoppingSessionService.FindSession(ctx, ct);

        if (!sessionResult.IsSuccess)
        {
            return sessionResult.Problem;
        }

        var session = sessionResult.Value;
        
        await cartItemRepository.DeleteAllBySessionAsync(session.Id, ct);
        await shoppingSessionService.ExtendSession(session, ct);
        
        return session.Id;
    }

    public async Task<Result<Id<ShoppingSession>>> UpdateCartItem(
        CartLineItem lineItem, ShoppingContext ctx, CancellationToken ct)
    {
        var sessionResult = await shoppingSessionService.FindSession(ctx, ct);
        
        if (!sessionResult.IsSuccess)
        {
            return sessionResult.Problem;
        }
        
        var session = sessionResult.Value;
        
        var result = await SetItemQuantity(
            session.Id, lineItem.Code, lineItem.Quantity, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        await shoppingSessionService.ExtendSession(session, ct);
        
        return session.Id;
    }

    private async Task<Result<CartItem>> AddItemQuantity(
        Id<ShoppingSession> sessionId, string code, int amount, CancellationToken ct)
    {
        var item = await cartItemRepository.FindBySessionAndCodeAsync(sessionId, code, ct);

        if (item is not null)
        {
            await SetNewQuantity(sessionId, item, newQuantity: item.Quantity + amount, ct);
            
            return item;
        }

        var sku = await skuRepository.FindByCodeAsync(code, ct);
        
        if (sku is null)
        {
            return CartItemProblems.SkuNotFound;
        }
        
        if (amount < 1 || amount > sku.Stock)
        {
            return CartItemProblems.InsufficientStock;
        }
        
        var newItem = CartItem.Create(sessionId, sku.Id, amount);
        
        return await cartItemRepository.CreateAsync(newItem, ct);
    }

    private async Task<Result<CartItem>> SetItemQuantity(
        Id<ShoppingSession> sessionId, string code, int quantity, CancellationToken ct)
    {
        var item = await cartItemRepository.FindBySessionAndCodeAsync(sessionId, code, ct);

        if (item is null)
        {
            return CartItemProblems.ItemNotFound;
        }

        await SetNewQuantity(sessionId, item, quantity, ct);
        
        return item;
    }

    private async Task SetNewQuantity(Id<ShoppingSession> sessionId, CartItem item, int newQuantity, CancellationToken ct)
    {
        var sku = item.Sku;
        var clampedQuantity = Math.Clamp(newQuantity, 0, sku.Stock);
        
        if (clampedQuantity <= 0)
        {
            await cartItemRepository.DeleteBySessionAndCodeAsync(sessionId, sku.Code, ct);
            
            return;
        }

        if (clampedQuantity == item.Quantity)
        {
            return;
        }

        item.Quantity = clampedQuantity;
        
        await cartItemRepository.UpdateAsync(item, ct);
    }

    public async Task<CartBag<TResult>> GetBag<TResult>(
        ShoppingContext ctx, Expression<Func<CartItem, TResult>> selector, CancellationToken ct)
    {
        var result = await shoppingSessionService.FindSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return CartBag<TResult>.Empty;
        }
        
        var session = result.Value;
        var items = await cartItemRepository.FindAllBySessionAsync(session.Id, selector, ct);
        
        return new CartBag<TResult>(session.Id, items);
    }
}