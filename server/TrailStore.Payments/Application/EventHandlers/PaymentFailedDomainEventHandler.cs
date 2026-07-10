using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Contracts.IntegrationEvents;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Application.EventHandlers;

[AppService<IEventHandler<PaymentFailedDomainEvent>>]
public class PaymentFailedDomainEventHandler(IPaymentOutbox outbox, IPaymentUnitOfWork unitOfWork) 
    : IEventHandler<PaymentFailedDomainEvent>
{
    public async Task HandleAsync(PaymentFailedDomainEvent evt, CancellationToken ct)
    {
        outbox.Enqueue(new PaymentFailedIntegrationEvent(WasCanceled: false, evt.ReferenceId));
        
        await unitOfWork.SaveAsync(ct);
    }
}