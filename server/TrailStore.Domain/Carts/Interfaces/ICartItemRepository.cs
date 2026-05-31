using System.Linq.Expressions;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Carts.Interfaces;

public interface ICartItemRepository
{
    Task<CartItem> UpdateAsync(CartItem item, CancellationToken ct);

    Task<CartItem> CreateAsync(CartItem item, CancellationToken ct);

    Task<CartItem?> FindBySessionAndCodeAsync(Id<ShoppingSession> sessionId, string code, CancellationToken ct);

    Task<List<TResult>> FindAllBySessionAsync<TResult>(
        Id<ShoppingSession> sessionId, Expression<Func<CartItem, TResult>> selector, CancellationToken ct);
    
    Task DeleteAllBySessionAsync(Id<ShoppingSession> sessionId, CancellationToken ct);

    Task DeleteBySessionAndCodeAsync(Id<ShoppingSession> sessionId, string code, CancellationToken ct);

    Task<int> CountBySessionAsync(Id<ShoppingSession> sessionId, CancellationToken ct);
    
    Task<decimal> CalculateSubtotalBySessionAsync(Id<ShoppingSession> sessionId, CancellationToken ct);
}