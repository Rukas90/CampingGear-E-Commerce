using Microsoft.Extensions.DependencyInjection;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Shared.Infrastructure.Events;

[AppService<IEventPublisher>]
public sealed class EventPublisher(IServiceProvider serviceProvider) : IEventPublisher
{
    public async Task PublishAsync<TEvent>(TEvent evt, CancellationToken ct) where TEvent : IEvent
    {
        using var scope = serviceProvider.CreateScope();
        var concreteType = evt.GetType();
        var handlerType = typeof(IEventHandler<>).MakeGenericType(concreteType);
        var handlers = scope.ServiceProvider.GetServices(handlerType).ToArray();
        var handleMethod = handlerType.GetMethod(nameof(IEventHandler<>.HandleAsync))!;

        foreach (var handler in handlers)
        {
            await (Task)handleMethod.Invoke(handler, [evt, ct])!;
        }
    }
}