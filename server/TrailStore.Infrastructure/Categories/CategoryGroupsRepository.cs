using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Categories.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Categories;

[AppService<ICategoryGroupsRepository>]
public class CategoryGroupsRepository(AppDbContext context)
    : ICategoryGroupsRepository
{
    public Task<List<CategoryGroup>> ListAsync(CancellationToken ct)
    {
        return context.CategoryGroups.ToListAsync(ct);
    }
}