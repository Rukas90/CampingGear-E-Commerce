using System.Linq.Expressions;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Infrastructure.Orders;

public interface IOrderItemsRepository
{
    Task<List<TResult>> ListMostSoldCategoriesAsync<TResult>(int count, Expression<Func<Category, TResult>> selector);
}