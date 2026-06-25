using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.Configurations;

namespace TrailStore.Shared.Infrastructure.Persistence;

public abstract class BaseDbContext<TContext>(DbContextOptions<TContext> options) 
    : DbContext(options), IUnitOfWork where TContext : DbContext
{
    protected abstract string DefaultSchema { get; }
    
    private sealed class WorkScope(
        IUnitOfWork unitOfWork, ITransaction transaction, bool isOwner, CancellationToken ct) : IWorkScope
    {
        private bool _completed = false;
        
        public async Task CompleteAsync()
        {
            await unitOfWork.SaveAsync(ct);
            _completed = true;
        }
    
        public async ValueTask DisposeAsync()
        {
            if (isOwner && _completed)
            {
                await transaction.CommitAsync(ct);
            }
            else if (!_completed)
            {
                await transaction.RollbackAsync(ct);
            }

            if (isOwner)
            {
                await transaction.DisposeAsync();
            }
        }
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder config)
    {
        DatabaseConventionConfiguration.ApplyDefaultConventions<TContext>(config);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TContext).Assembly);
        
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var type = entityType.ClrType;
        
            while (type != null)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(AggregateRoot<>))
                {
                    modelBuilder.Entity(entityType.ClrType).Ignore("DomainEvents");
                    
                    break;
                }
                type = type.BaseType;
            }
        }

        base.OnModelCreating(modelBuilder);
    }
    
    public async Task<IWorkScope> BeginScope(CancellationToken ct)
    {
        var hasActiveTransaction = HasActiveTransaction;
        var transaction = await BeginOrJoinTransactionAsync(ct);
        
        return new WorkScope(this, transaction, !hasActiveTransaction, ct);
    }
    
    public async Task<ITransaction> BeginOrJoinTransactionAsync(CancellationToken ct)
    {
        if (HasActiveTransaction)
        {
            return new EfTransaction(Database.CurrentTransaction!);
        }
        
        return new EfTransaction(await Database.BeginTransactionAsync(ct));
    }
    
    private bool HasActiveTransaction => Database.CurrentTransaction is not null;

    public async Task SaveAsync(CancellationToken ct)
    {
        UpdateAuditedEntities();
        
        await SaveChangesAsync(ct);
    }

    private void UpdateAuditedEntities()
    {
        var entities = ChangeTracker.Entries<ITrackedEntity>();

        foreach (var entry in entities)
        {
            if (entry.State is EntityState.Added && entry.Entity is IEntityCreatable creatable)
            {
                creatable.OnCreated();
            }

            if (entry.State is EntityState.Added or EntityState.Modified
                && entry.Entity is IEntityUpdateable updateable)
            {
                updateable.OnUpdated();
            }
        }
    }
}