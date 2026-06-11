using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Data;

[AppService<IUnitOfWork>]
public sealed class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private sealed class WorkScope(
        UnitOfWork unitOfWork, IDbContextTransaction transaction, bool isOwner, CancellationToken ct) 
        : IWorkScope
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
    
    private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    
    public async Task<IWorkScope> BeginScope(CancellationToken ct)
    {
        var hasActiveTransaction = HasActiveTransaction;
        var transaction = await BeginOrJoinTransactionAsync(ct);
        
        return new WorkScope(this, transaction, !hasActiveTransaction, ct);
    }
    
    public async Task<IDbContextTransaction> BeginOrJoinTransactionAsync(CancellationToken ct)
    {
        if (HasActiveTransaction)
        {
            return _context.Database.CurrentTransaction!;
        }
        
        return await _context.Database.BeginTransactionAsync(ct);
    }
    
    private bool HasActiveTransaction => _context.Database.CurrentTransaction is not null;

    public async Task SaveAsync(CancellationToken ct)
    {
        UpdateAuditedEntities();
        
        await _context.SaveChangesAsync(ct);
    }

    private void UpdateAuditedEntities()
    {
        var entities = _context.ChangeTracker.Entries<ITrackedEntity>();

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