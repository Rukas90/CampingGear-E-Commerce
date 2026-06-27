using System.Linq.Expressions;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Catalog.Domain.Categories;

public interface ICategoryRepository : IReadRepository<Category>
{
    Task<List<TResult>> ListMostSoldCategoriesAsync<TResult>(int count,
        Expression<Func<Category, TResult>> selector, CancellationToken ct);
    
    Task<List<Category>> ListAllCategoriesAsync(CancellationToken ct);
}