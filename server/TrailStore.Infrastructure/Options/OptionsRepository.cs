using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Options;

public interface IOptionsRepository
{
    Task<List<TResult>> ListAllAsync<TResult>(
        Specification<OptionGroup> specification, Expression<Func<OptionGroup, TResult>> selector);
}
public class OptionsRepository(AppDbContext context) : IOptionsRepository
{
    public Task<List<TResult>> ListAllAsync<TResult>(
        Specification<OptionGroup> specification, Expression<Func<OptionGroup, TResult>> selector)
    {
        return context.OptionGroups
            .Where(specification.ToExpression())
            .Select(selector)
            .ToListAsync();
    }
}