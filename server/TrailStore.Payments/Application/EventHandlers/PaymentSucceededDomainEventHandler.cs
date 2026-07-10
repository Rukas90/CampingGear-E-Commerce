using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Contracts.IntegrationEvents;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Application.EventHandlers;

[AppService<IEventHandler<PaymentConfirmedDomainEvent>>]
public class PaymentSucceededDomainEventHandler(IPaymentOutbox outbox) 
    : IEventHandler<PaymentConfirmedDomainEvent>
{
    public async Task HandleAsync(PaymentConfirmedDomainEvent evt, CancellationToken ct)
    {
        outbox.Enqueue(new PaymentSucceededIntegrationEvent(evt.PaymentId, evt.ReferenceId));
        await outbox.SaveAsync(ct);
    }
}