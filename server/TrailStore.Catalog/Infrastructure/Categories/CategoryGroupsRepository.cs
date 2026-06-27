using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Domain.Categories;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Catalog.Infrastructure.Categories;

[AppService<ICategoryGroupsRepository>]
public sealed class CategoryGroupsRepository(CatalogDbContext _context) 
    : ReadRepository<CategoryGroup, CatalogDbContext>(_context), ICategoryGroupsRepository
{
    public Task<List<CategoryGroup>> ListAsync(CancellationToken ct)
        => ReadQuery.ToListAsync(ct);
}