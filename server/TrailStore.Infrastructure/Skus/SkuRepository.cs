using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.Skus.Interfaces;
using TrailStore.Domain.Skus.Specifications;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Skus;

[AppService<ISkuRepository>]
public class SkuRepository(AppDbContext context) : ISkuRepository
{
    public Task<List<TResult>> ListAllAsync<TResult>(
        Specification<Sku> specification, Expression<Func<Sku, TResult>> selector, CancellationToken ct)
    {
        return context.Skus
            .Where(specification.ToExpression())
            .Select(selector)
            .ToListAsync(ct);
    }

    public async Task<Sku?> FindByCodeAsync(string code, CancellationToken ct)
    {
        return await context.Skus
            .AsQueryable()
            .Where(SkuSpecifications.Code(code).ToExpression())
            .FirstOrDefaultAsync(ct);
    }
}