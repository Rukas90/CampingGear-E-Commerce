using Microsoft.Extensions.Logging;
using TrailStore.Inventory.Application.Abstractions;
using TrailStore.Inventory.Contracts;
using TrailStore.Inventory.Contracts.IntegrationEvents;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Inventory.Application.Commands;

[AppService<RestockItemsCommandHandler>]
public sealed class RestockItemsCommandHandler(
    IInventoryItemRepository repository,
    ILogger<RestockItemsCommandHandler> logger,
    IInventoryOutbox outbox,
    IInventoryUnitOfWork unitOfWork)
    : ICommandHandler<RestockItemsCommand>
{
    public async Task<Result> Handle(RestockItemsCommand command, CancellationToken ct)
    {
        var items = await repository.FindLowStockItemsAsync(ct);

        if (items.Count <= 0)
        {
            logger.LogInformation("No items to restock");
            
            return Result.Ok();
        }
        
        var changedItems = new List<ItemChangedStock>(items.Count);
        
        foreach (var item in items)
        {
            var quantity = Random.Shared.Next(2, 11);
            var result = item.AddStock(quantity);

            if (!result.IsSuccess)
            {
                logger.LogError("Failed trying to restock an item. Reason: {Reason}", result.Problem.Reason);

                continue;
            }
            
            changedItems.Add(new ItemChangedStock(item.SkuId, item.Stock));
        }
        
        if (changedItems.Count == 0)
        {
            logger.LogInformation("No items were successfully restocked");
            
            return Result.Ok();
        }
        
        outbox.AddMessage(new ItemsStockChangedIntegrationEvent(changedItems));
        
        await unitOfWork.SaveAsync(ct);
        
        logger.LogInformation("{Count} items were successfully restocked", changedItems.Count);
        
        return Result.Ok();
    }
}