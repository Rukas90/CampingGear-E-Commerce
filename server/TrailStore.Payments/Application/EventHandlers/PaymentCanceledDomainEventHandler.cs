using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Contracts.IntegrationEvents;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Application.EventHandlers;

[AppService<IEventHandler<PaymentCanceledDomainEvent>>]
public class PaymentCanceledDomainEventHandler(IPaymentOutbox outbox) 
    : IEventHandler<PaymentCanceledDomainEvent>
{
    public async Task HandleAsync(PaymentCanceledDomainEvent evt, CancellationToken ct)
    {
        outbox.Enqueue(new PaymentCanceledIntegrationEvent(evt.PaymentId, evt.ReferenceId));
        await outbox.SaveAsync(ct);
    }
}