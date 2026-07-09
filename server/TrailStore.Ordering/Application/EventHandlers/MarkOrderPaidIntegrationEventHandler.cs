using Microsoft.Extensions.Logging;
using TrailStore.Inventory.Contracts;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Payments.Contracts.IntegrationEvents;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.EventHandlers;

[AppService<IEventHandler<PaymentSucceededIntegrationEvent>>]
public sealed class MarkOrderPaidIntegrationEventHandler(
    IOrderRepository repository, 
    IInventoryService inventoryService, 
    IOrderingUnitOfWork unitOfWork,
    ILogger<MarkOrderPaidIntegrationEventHandler> logger,
    IEventPublisher publisher)
    : IEventHandler<PaymentSucceededIntegrationEvent>
{
    public async Task HandleAsync(PaymentSucceededIntegrationEvent evt, CancellationToken ct)
    {
        try
        {
            var order = await repository.FindAsync(evt.ReferenceId, ct);

            if (order is null)
            {
                throw new InvalidOperationException($"Order with reference id {evt.ReferenceId} not found.");
            }

            var result = await inventoryService.ConfirmReservedStock(order.Items.Select(item => new StockReserveItem
            {
                SkuId = item.SkuId,
                Units = item.Quantity
            }).ToArray(), ct);

            if (!result.IsSuccess)
            {
                throw new InvalidOperationException("Order reserved stock confirmation has failed.");
            }
        
            order.MarkAsPaid();

            await unitOfWork.SaveAsync(ct);
        }
        catch (Exception e)
        {
            logger.LogError("Error occurred while marking order as paid. Message: {Message}", e.Message);
            
            await publisher.PublishAsync(new PaymentRefundedIntegrationEvent(evt.PaymentId), ct);
        }
    }
}