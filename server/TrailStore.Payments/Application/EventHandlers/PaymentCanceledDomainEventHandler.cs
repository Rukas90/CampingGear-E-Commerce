using TrailStore.Payments.Contracts.IntegrationEvents;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Application.EventHandlers;

[AppService<IEventHandler<PaymentCanceledDomainEvent>>]
public class PaymentCanceledDomainEventHandler(IEventPublisher publisher) 
    : IEventHandler<PaymentCanceledDomainEvent>
{
    public Task HandleAsync(PaymentCanceledDomainEvent evt, CancellationToken ct)
        => publisher.PublishAsync(new PaymentCanceledIntegrationEvent(evt.PaymentId, evt.ReferenceId), ct);
}