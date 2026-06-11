using System.Linq.Expressions;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Categories.Interfaces;

public interface ICategoriesRepository
{
    Task<List<TResult>> ListMostSoldCategoriesAsync<TResult>(int count,
        Expression<Func<Category, TResult>> selector, CancellationToken ct);
    
    Task<List<Category>> ListAllCategoriesAsync(CancellationToken ct);
}