using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Domain.Messages;

namespace TrailStore.Shared.Infrastructure.Outbox;

public sealed class OutboxProcessor<TOutbox>(
    IServiceScopeFactory scopeFactory,
    ILogger<OutboxProcessor<TOutbox>> logger) : BackgroundService
    where TOutbox : IOutbox
{
    private const int MaxRetries = 5;
    private readonly TimeSpan PollInterval = TimeSpan.FromSeconds(2);
    
    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(Random.Shared.Next(0, 500)), ct);
 
        while (!ct.IsCancellationRequested)
        {
            try
            {
                await ProcessBatchAsync(ct);
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested)
            {
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Outbox processing loop failed unexpectedly for {Outbox}", typeof(TOutbox).Name);
            }
 
            try
            {
                await Task.Delay(PollInterval, ct);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
    
    private async Task ProcessBatchAsync(CancellationToken ct)
    {
        using var scope = scopeFactory.CreateScope();
 
        var outbox = scope.ServiceProvider.GetRequiredService<TOutbox>();
        var publisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();
 
        var messages = outbox.GetMessages();
        var pending = await messages.QueryUnprocessed(takeCount: 20, ct);

        if (pending.Length == 0)
        {
            return;
        }
 
        foreach (var message in pending)
        {
            if (message.RetryCount >= MaxRetries)
            {
                continue;
            }
 
            try
            {
                var type = Type.GetType(message.Type) ?? throw new InvalidOperationException($"Could not resolve type '{message.Type}'");
 
                var evt = (IEvent)JsonSerializer.Deserialize(message.Payload, type)!;
 
                await publisher.PublishAsync(evt, ct);
 
                message.MarkAsProcessed();
            }
            catch (Exception ex)
            {
                message.MarkAsFailed(ex.Message);
                logger.LogError(ex, "Failed to dispatch outbox message {Id} ({Type}), attempt {RetryCount}", message.Id, message.Type, message.RetryCount + 1);
            }
        }
        
        await outbox.SaveAsync(ct);
    }
}