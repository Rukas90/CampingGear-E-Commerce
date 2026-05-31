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
    public async Task<CartItem> UpdateAsync(CartItem item, CancellationToken ct)
    {
        context.CartItems.Update(item);
        await context.SaveChangesAsync(ct);

        return item;
    }

    public async Task<CartItem> CreateAsync(CartItem item, CancellationToken ct)
    {
        await context.CartItems.AddAsync(item, ct);
        await context.SaveChangesAsync(ct);

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
            .Where(item => item.ShoppingSession.Id == sessionId)
            .Select(selector)
            .ToListAsync(ct);
    }

    public Task DeleteAllBySessionAsync(Id<ShoppingSession> sessionId, CancellationToken ct)
    {
        return context.CartItems
            .Where(item => item.SessionId == sessionId)
            .ExecuteDeleteAsync(ct);
    }

    public Task DeleteBySessionAndCodeAsync(Id<ShoppingSession> sessionId, string code, CancellationToken ct)
    {
        return context.CartItems
            .Include(item => item.Sku)
            .Where(item => item.SessionId == sessionId 
                           && item.Sku.Code == code)
            .ExecuteDeleteAsync(ct);
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