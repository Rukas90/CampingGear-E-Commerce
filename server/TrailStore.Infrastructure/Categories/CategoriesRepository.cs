using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Categories.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Categories;

[AppService<ICategoriesRepository>]
public class CategoriesRepository(AppDbContext context) : ICategoriesRepository
{
    public Task<List<TResult>> ListMostSoldCategoriesAsync<TResult>(int count,
        Expression<Func<Category, TResult>> selector, CancellationToken ct)
    {
        return context.Categories
            .GroupJoin(
                context.OrderItems,
                c => c.Id,
                oi => oi.Sku.Product.CategoryId,
                (c, items) => new
                {
                    Category = c,
                    TotalSold = items.Sum(oi => (int?)oi.Quantity) ?? 0
                })
            .OrderByDescending(x => x.TotalSold)
            .Take(count)
            .Select(x => x.Category)
            .Select(selector)
            .ToListAsync(ct);
    }
    
    public Task<List<Category>> ListAllCategoriesAsync(CancellationToken ct)
    {
        return context.Categories
            .Include(category => category.Group)
            .ToListAsync(ct);
    }
}