using Microsoft.Extensions.Logging;
using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Contracts.IntegrationEvents;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.EventHandlers;

[AppService<IEventHandler<OrderCreatedIntegrationEvent>>]
internal sealed class OrderCreatedIntegrationEventHandler(
    ICartSessionService cartSessionService, 
    ILogger<OrderCreatedIntegrationEventHandler> logger,
    IBasketUnitOfWork unitOfWork) : IEventHandler<OrderCreatedIntegrationEvent>
{
    public async Task HandleAsync(OrderCreatedIntegrationEvent evt, CancellationToken ct)
    {
        var result = await cartSessionService.FindCart(
            Id<Cart>.FromNullable(evt.CartId), 
            Id<UserRef>.FromNullable(evt.UserId), ct);

        if (!result.IsSuccess)
        {
            logger.LogWarning("Could not find cart for OrderCreated event {EventId}. UserId: {UserId}, CartId: {CartId}",
                evt.Id, evt.UserId, evt.CartId);
            
            return;
        }

        var cart = result.Value;
        
        cart.Clear();

        await unitOfWork.SaveAsync(ct);
    }
}