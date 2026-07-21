using System.Threading.Channels;
using TrailStore.Shared.Domain.Messages;

namespace TrailStore.Shared.Infrastructure.Outbox;

public sealed class OutboxSignal<TOutbox> where TOutbox : IOutbox
{
    private readonly Channel<bool> _channel = Channel.CreateBounded<bool>(
        new BoundedChannelOptions(1) { FullMode = BoundedChannelFullMode.DropOldest });

    public void NotifyNewMessages() => _channel.Writer.TryWrite(true);

    public IAsyncEnumerable<bool> WaitForMessagesAsync(CancellationToken ct) 
        => _channel.Reader.ReadAllAsync(ct);
}