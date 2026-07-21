using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TrailStore.Shared.Domain.Messages;

namespace TrailStore.Shared.Infrastructure.Outbox;

public sealed class OutboxSignalInterceptor<TOutbox>(OutboxSignal<TOutbox> signal) 
    : SaveChangesInterceptor
    where TOutbox : IOutbox
{
    private bool _hasOutboxMessages;

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            _hasOutboxMessages = eventData.Context.ChangeTracker
                .Entries<OutboxMessage>().Any(e => e.State == EntityState.Added);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        if (_hasOutboxMessages)
        {
            signal.NotifyNewMessages();
            _hasOutboxMessages = false;
        }

        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }
}