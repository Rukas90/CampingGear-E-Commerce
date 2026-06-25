using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Domain.Categories;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Infrastructure.Categories;

[AppService<ICategoryRepository>]
public class CategoryRepository(CatalogDbContext context) : ICategoryRepository
{
    public Task<List<TResult>> ListMostSoldCategoriesAsync<TResult>(
        int count, Expression<Func<Category, TResult>> selector, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> ListAllCategoriesAsync(CancellationToken ct)
        => context.Categories.Include(c => c.Group).ToListAsync(ct);
}