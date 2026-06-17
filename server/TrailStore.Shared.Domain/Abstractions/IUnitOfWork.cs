namespace TrailStore.Shared.Domain.Abstractions;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken ct);

    Task<IWorkScope> BeginScope(CancellationToken ct);
    
    Task<ITransaction> BeginOrJoinTransactionAsync(CancellationToken ct);
}