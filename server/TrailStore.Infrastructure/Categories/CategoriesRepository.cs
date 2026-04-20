using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Models;
using TrailStore.Infrastructure.Data;

namespace TrailStore.Infrastructure.Categories;

public class CategoriesRepository(AppDbContext context) : ICategoriesRepository
{
    public Task<List<Category>> ListAllAsync()
    {
        return context.Categories.ToListAsync();
    }
}