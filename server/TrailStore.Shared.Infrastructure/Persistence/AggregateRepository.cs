using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Infrastructure.Persistence;

public abstract class AggregateRepository<TEntity, TContext>(TContext _context) : IAggregateRepository<TEntity>
    where TEntity : AggregateRoot<TEntity> 
    where TContext : DbContext
{
    private readonly TContext context = _context ?? throw new ArgumentNullException(nameof(_context));
    
    private DbSet<TEntity> set => context.Set<TEntity>();

    protected IQueryable<TEntity> AggregateQuery => BuildAggregateQuery(set);
    protected IQueryable<TEntity> ReadQuery => set.AsNoTracking();
    
    public Task<TEntity?> FindAsync(Id<TEntity> id, CancellationToken ct) 
        => BuildAggregateQuery(set).SingleOrDefaultAsync(entity => entity.Id == id, ct);
    
    public void Add(TEntity entity)
        => set.Add(entity);
    
    public void Delete(TEntity entity)
        => set.Remove(entity);

    protected abstract IQueryable<TEntity> BuildAggregateQuery(DbSet<TEntity> set);
}