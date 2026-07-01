using Microsoft.Extensions.Logging;
using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Ordering.Contracts.IntegrationEvents;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.EventHandlers;

[AppService<IEventHandler<OrderCreatedIntegrationEvent>>]
internal sealed class OrderCreatedIntegrationEventHandler(
    IShoppingSessionService shoppingSessionService, 
    ILogger<OrderCreatedIntegrationEventHandler> logger,
    IBasketUnitOfWork unitOfWork) : IEventHandler<OrderCreatedIntegrationEvent>
{
    public async Task HandleAsync(OrderCreatedIntegrationEvent evt, CancellationToken ct)
    {
        var result = await shoppingSessionService.FindSession(
                new ShoppingContext(evt.UserId, evt.SessionId), ct);

        if (!result.IsSuccess)
        {
            logger.LogWarning("Could not find shopping session for OrderCreated event {EventId}. UserId: {UserId}, SessionId: {SessionId}",
                evt.Id, evt.UserId, evt.SessionId);
            
            return;
        }

        var session = result.Value;
        
        session.ClearCart();

        await unitOfWork.SaveAsync(ct);
    }
}