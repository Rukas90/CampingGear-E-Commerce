using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Infrastructure.Persistence;

public abstract class ReadRepository<TEntity, TContext>(TContext _context) : IReadRepository<TEntity>
    where TEntity : class, IModel<TEntity>
    where TContext : DbContext
{
    private readonly TContext context = _context ?? throw new ArgumentNullException(nameof(_context));
    
    private DbSet<TEntity> set => context.Set<TEntity>();
    
    protected IQueryable<TEntity> ReadQuery => BuildAggregateQuery(set).AsNoTracking();
    
    public Task<TEntity?> FindAsync(Id<TEntity> id, CancellationToken ct) 
        => BuildAggregateQuery(set).SingleOrDefaultAsync(entity => entity.Id == id, ct);

    protected virtual IQueryable<TEntity> BuildAggregateQuery(DbSet<TEntity> set) => set;
}