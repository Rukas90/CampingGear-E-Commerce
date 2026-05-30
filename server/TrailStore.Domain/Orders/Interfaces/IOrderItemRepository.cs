using System.Linq.Expressions;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderItemRepository
{
    Task<List<TResult>> ListMostSoldCategoriesAsync<TResult>(int count,
        Expression<Func<Category, TResult>> selector, CancellationToken ct);
    
    Task AddItemsAsync(OrderItem[] items, CancellationToken ct);
}