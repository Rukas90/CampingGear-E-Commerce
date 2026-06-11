using System.Linq.Expressions;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Carts.Interfaces;

public interface ICartItemRepository
{
    void Update(CartItem item);

    CartItem Add(CartItem item);

    Task<CartItem?> FindBySessionAndCodeAsync(Id<ShoppingSession> sessionId, string code, CancellationToken ct);

    Task<List<TResult>> FindAllBySessionAsync<TResult>(
        Id<ShoppingSession> sessionId, Expression<Func<CartItem, TResult>> selector, CancellationToken ct);
    
    Task DeleteAllBySessionAsync(Id<ShoppingSession> sessionId, CancellationToken ct);

    void Remove(CartItem item);
    
    Task DeleteBySessionAndCodeAsync(Id<ShoppingSession> sessionId, string code, CancellationToken ct);

    Task<int> CountBySessionAsync(Id<ShoppingSession> sessionId, CancellationToken ct);
    
    Task<decimal> CalculateSubtotalBySessionAsync(Id<ShoppingSession> sessionId, CancellationToken ct);
}