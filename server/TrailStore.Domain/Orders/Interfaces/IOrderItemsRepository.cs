using System.Linq.Expressions;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderItemsRepository
{
    Task<List<TResult>> ListMostSoldCategoriesAsync<TResult>(int count,
        Expression<Func<Category, TResult>> selector, CancellationToken ct);
}