using Microsoft.Extensions.Logging;
using TrailStore.Catalog.Application.Abstractions;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Inventory.Contracts.IntegrationEvents;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Application.EventHandlers;

[AppService<IEventHandler<ItemsStockChangedIntegrationEvent>>]
public sealed class StocksChangedIntegrationEventHandler(
    IProductsRepository productsRepository,
    ILogger<StocksChangedIntegrationEventHandler> logger, 
    ICatalogUnitOfWork unitOfWork) : IEventHandler<ItemsStockChangedIntegrationEvent>
{
    public async Task HandleAsync(ItemsStockChangedIntegrationEvent evt, CancellationToken ct)
    {
        var stockBySkuId = evt.ChangedItems.ToDictionary(item => item.SkuId, item => item.Stock);

        var products = await productsRepository.FindAllFromSkuIdsAsync(
            stockBySkuId.Keys.Select(Id<Sku>.From), ct);

        if (products.Count <= 0)
        {
            return;
        }

        foreach (var product in products)
        {
            foreach (var sku in product.Skus)
            {
                if (!stockBySkuId.TryGetValue(sku.Id.Value, out var newStock))
                {
                    continue;
                }

                var result = product.UpdateStock(sku.Id, newStock);

                if (!result.IsSuccess)
                {
                    logger.LogError(
                        "Failed to update stock for product {ProductId}, sku {SkuId}. Reason: {Reason}",
                        product.Id, sku.Id, result.Problem.Reason);
                }
            }
        }

        await unitOfWork.SaveAsync(ct);
        
        logger.LogInformation("Sku stock updated.");
    }
}