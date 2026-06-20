using System.Linq.Expressions;

namespace TrailStore.Catalog.Domain.Categories;

public interface ICategoryRepository
{
    Task<List<TResult>> ListMostSoldCategoriesAsync<TResult>(int count,
        Expression<Func<Category, TResult>> selector, CancellationToken ct);
    
    Task<List<Category>> ListAllCategoriesAsync(CancellationToken ct);
}