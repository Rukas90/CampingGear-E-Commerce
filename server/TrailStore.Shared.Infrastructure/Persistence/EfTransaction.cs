using Microsoft.EntityFrameworkCore.Storage;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Shared.Infrastructure.Persistence;

public class EfTransaction(IDbContextTransaction transaction) : ITransaction
{
    public async Task CommitAsync(CancellationToken ct) 
        => await transaction.CommitAsync(ct);
    
    public async Task RollbackAsync(CancellationToken ct) 
        => await transaction.RollbackAsync(ct);
    
    public async ValueTask DisposeAsync()
    {
        await transaction.DisposeAsync();
        GC.SuppressFinalize(this);
    }
}