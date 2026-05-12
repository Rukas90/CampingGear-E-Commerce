using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Categories.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Categories;

[AppService<ICategoriesRepository>]
public class CategoriesRepository(AppDbContext context) : ICategoriesRepository
{
    public Task<List<Category>> ListAllCategoriesAsync(CancellationToken ct)
    {
        return context.Categories
            .Include(category => category.Group)
            .ToListAsync(ct);
    }

    public Task<List<CategoryGroup>> ListAllCategoryGroupsAsync(CancellationToken ct)
    {
        return context.CategoryGroups.ToListAsync(ct);
    }
}