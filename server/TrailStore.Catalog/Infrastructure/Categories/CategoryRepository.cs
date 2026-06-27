using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Domain.Categories;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Catalog.Infrastructure.Categories;

[AppService<ICategoryRepository>]
public sealed class CategoryRepository(CatalogDbContext _context) 
    : ReadRepository<Category, CatalogDbContext>(_context), ICategoryRepository
{
    public Task<List<TResult>> ListMostSoldCategoriesAsync<TResult>(
        int count, Expression<Func<Category, TResult>> selector, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> ListAllCategoriesAsync(CancellationToken ct)
        => ReadQuery.Include(c => c.Group).ToListAsync(ct);
}