using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Carts.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Carts;

[AppService<ICartItemRepository>]
public class CartItemRepository(AppDbContext context) : ICartItemRepository
{
    public void Update(CartItem item)
    {
        context.CartItems.Update(item);
    }

    public CartItem Add(CartItem item)
    {
        context.CartItems.Add(item);

        return item;
    }

    public async Task<CartItem?> FindBySessionAndCodeAsync(Id<ShoppingSession> sessionId, string code, CancellationToken ct)
    {
        return await context.CartItems.Include(item => item.Sku).FirstOrDefaultAsync(
            item => item.ShoppingSession.Id == sessionId && item.Sku.Code == code, ct);
    }

    public async Task<List<TResult>> FindAllBySessionAsync<TResult>(
        Id<ShoppingSession> sessionId, Expression<Func<CartItem, TResult>> selector, CancellationToken ct)
    {
        return await context.CartItems
            .Where(item => item.SessionId == sessionId)
            .Select(selector)
            .ToListAsync(ct);
    }

    public async Task DeleteAllBySessionAsync(Id<ShoppingSession> sessionId, CancellationToken ct)
    {
        var items = await context.CartItems
            .Where(item => item.SessionId == sessionId)
            .ToArrayAsync(ct);
        
        context.CartItems.RemoveRange(items);
    }
    
    public void Remove(CartItem item)
        => context.CartItems.Remove(item);

    public async Task DeleteBySessionAndCodeAsync(Id<ShoppingSession> sessionId, string code, CancellationToken ct)
    {
        var item = await context.CartItems
            .Where(item => item.SessionId == sessionId && item.Sku.Code == code)
            .FirstOrDefaultAsync(ct);

        if (item is not null)
        {
            context.CartItems.Remove(item);
        }
    }

    public async Task<int> CountBySessionAsync(Id<ShoppingSession> sessionId, CancellationToken ct)
    {
        return await context.CartItems
            .Where(item => item.SessionId == sessionId)
            .SumAsync(item => item.Quantity, ct);
    }

    public async Task<decimal> CalculateSubtotalBySessionAsync(Id<ShoppingSession> sessionId, CancellationToken ct)
    {
        return await context.CartItems
            .Where(item => item.SessionId == sessionId)
            .SumAsync(item => item.Sku.UnitPrice * item.Quantity, ct);
    }
}