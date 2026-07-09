using TrailStore.Payments.Contracts.IntegrationEvents;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Application.EventHandlers;

[AppService<IEventHandler<PaymentConfirmedDomainEvent>>]
public class PaymentSucceededDomainEventHandler(IEventPublisher publisher) 
    : IEventHandler<PaymentConfirmedDomainEvent>
{
    public Task HandleAsync(PaymentConfirmedDomainEvent evt, CancellationToken ct)
        => publisher.PublishAsync(new PaymentSucceededIntegrationEvent(evt.PaymentId, evt.ReferenceId), ct);
}