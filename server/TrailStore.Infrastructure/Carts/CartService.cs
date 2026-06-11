using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using TrailStore.Domain.Carts.Errors;
using TrailStore.Domain.Carts.Interfaces;
using TrailStore.Domain.Carts.Models;
using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Interfaces;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Domain.Skus.Interfaces;
using TrailStore.Infrastructure.ShoppingSessions;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Carts;

[AppService<ICartService>]
public class CartService(
    IShoppingSessionService shoppingSessionService,
    ISkuRepository skuRepository,
    ICartItemRepository cartItemRepository,
    IOptions<ShoppingSessionOptions> shoppingSessionOptions,
    IUnitOfWork unitOfWork) : ICartService
{
    public async Task<Result<Id<ShoppingSession>>> AddItemToCart(
        CartLineItem lineItem, ShoppingContext ctx, CancellationToken ct)
    {
        await using var scope = await unitOfWork.BeginScope(ct);
        
        var session = await shoppingSessionService.FindOrCreateSession(ctx, ct);
        
        var result = await AddItemQuantity(
            session.Id, lineItem.Code, lineItem.Quantity, ct);
        
        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        session.Extend(shoppingSessionOptions.Value.ExpiryTime);
        
        await scope.CompleteAsync();
        
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
        
        await using var scope = await unitOfWork.BeginScope(ct);
        
        await cartItemRepository.DeleteBySessionAndCodeAsync(session.Id, code, ct);
        
        session.Extend(shoppingSessionOptions.Value.ExpiryTime);
        
        await scope.CompleteAsync();
        
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

        await using var scope = await unitOfWork.BeginScope(ct);

        await cartItemRepository.DeleteAllBySessionAsync(session.Id, ct);
        
        session.Extend(shoppingSessionOptions.Value.ExpiryTime);

        await scope.CompleteAsync();
        
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
        
        await using var scope = await unitOfWork.BeginScope(ct);
        
        var session = sessionResult.Value;
        
        var result = await SetItemQuantity(
            session.Id, lineItem.Code, lineItem.Quantity, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        session.Extend(shoppingSessionOptions.Value.ExpiryTime);

        await scope.CompleteAsync();
        
        return session.Id;
    }

    private async Task<Result<CartItem>> AddItemQuantity(
        Id<ShoppingSession> sessionId, string code, int amount, CancellationToken ct)
    {
        var item = await cartItemRepository.FindBySessionAndCodeAsync(sessionId, code, ct);

        if (item is not null)
        {
            SetNewQuantity(item, newQuantity: item.Quantity + amount);
            
            return item;
        }

        var sku = await skuRepository.FindByCodeAsync(code, ct);
        
        if (sku is null)
        {
            return CartItemProblems.SkuNotFound;
        }
        
        if (amount < 1 || amount > sku.AvailableStock)
        {
            return CartItemProblems.InsufficientStock;
        }
        
        return cartItemRepository.Add(CartItem.Create(sessionId, sku.Id, amount));
    }

    private async Task<Result<CartItem>> SetItemQuantity(
        Id<ShoppingSession> sessionId, string code, int quantity, CancellationToken ct)
    {
        var item = await cartItemRepository.FindBySessionAndCodeAsync(sessionId, code, ct);

        if (item is null)
        {
            return CartItemProblems.ItemNotFound;
        }

        SetNewQuantity(item, quantity);
        
        return item;
    }

    private void SetNewQuantity(CartItem item, int newQuantity)
    {
        var sku = item.Sku;
        var clampedQuantity = Math.Clamp(newQuantity, 0, sku.AvailableStock);
        
        if (clampedQuantity <= 0)
        {
            cartItemRepository.Remove(item);
            
            return;
        }

        if (clampedQuantity == item.Quantity)
        {
            return;
        }

        item.SetQuantity(clampedQuantity);
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