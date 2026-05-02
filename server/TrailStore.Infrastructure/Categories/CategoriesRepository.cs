using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Categories;
using TrailStore.Domain.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Categories;

[AppService<ICategoriesRepository>]
public class CategoriesRepository(AppDbContext context) : ICategoriesRepository
{
    public Task<List<Category>> ListAllAsync()
    {
        return context.Categories.ToListAsync();
    }
}