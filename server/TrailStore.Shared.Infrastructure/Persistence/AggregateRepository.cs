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

    protected IQueryable<TEntity> AggregateWriteQuery => BuildAggregateQuery(set);
    protected IQueryable<TEntity> AggregateReadQuery => BuildAggregateQuery(set).AsNoTracking();
    protected IQueryable<TEntity> ReadQuery => set.AsNoTracking();
    
    public Task<TEntity?> FindAsync(Id<TEntity> id, CancellationToken ct) 
        => BuildAggregateQuery(set).SingleOrDefaultAsync(entity => entity.Id == id, ct);

    public TEntity Add(TEntity entity)
    {
        set.Add(entity);
        
        return entity;
    }
    
    public void Delete(TEntity entity)
        => set.Remove(entity);

    protected virtual IQueryable<TEntity> BuildAggregateQuery(DbSet<TEntity> set) => set;
}