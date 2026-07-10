using Microsoft.Extensions.Logging;
using TrailStore.Inventory.Contracts;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Payments.Contracts.IntegrationEvents;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.EventHandlers;

[AppService<IEventHandler<PaymentFailedIntegrationEvent>>]
public sealed class MarkOrderBasedOnFailedPaymentIntegrationEventHandler(
    IOrderRepository orderRepository, 
    IInventoryService inventoryService, 
    IOrderingUnitOfWork unitOfWork,
    ILogger<MarkOrderPaidIntegrationEventHandler> logger) 
    : IEventHandler<PaymentFailedIntegrationEvent>
{
    public async Task HandleAsync(PaymentFailedIntegrationEvent evt, CancellationToken ct)
    {
        var order = await orderRepository.FindAsync(evt.ReferenceId, ct);

        if (order is null)
        {
            logger.LogError("Order with reference id {ReferenceId} not found", evt.ReferenceId);
            
            return;
        }
        
        var result = await inventoryService.RevertReservedStock(order.Items.Select(item => new StockReserveItem
        {
            SkuId = item.SkuId,
            Units = item.Quantity
        }).ToArray(), ct);

        if (!result.IsSuccess)
        {
            logger.LogError("Order reserved stock revert action has failed. Reason: {Reason}", result.Problem.Reason);
        }

        if (evt.WasCanceled)
        {
            order.MarkAsCanceled();
        }
        else
        {
            order.MarkPaymentFailed();
        }

        await unitOfWork.SaveAsync(ct);
    }
}