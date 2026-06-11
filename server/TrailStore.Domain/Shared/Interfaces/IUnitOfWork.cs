using Microsoft.EntityFrameworkCore.Storage;

namespace TrailStore.Domain.Shared.Interfaces;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken ct);

    Task<IWorkScope> BeginScope(CancellationToken ct);
    
    Task<IDbContextTransaction> BeginOrJoinTransactionAsync(CancellationToken ct);
}