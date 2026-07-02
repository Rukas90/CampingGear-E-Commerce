using Microsoft.Extensions.Logging;
using TrailStore.Catalog.Application.Abstractions;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Inventory.Contracts.IntegrationEvents;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Application.EventHandlers;

[AppService<IEventHandler<StockChangedIntegrationEvent>>]
internal sealed class StockChangedIntegrationEventHandler(
    IProductsRepository productsRepository,
    ILogger<StockChangedIntegrationEventHandler> logger, 
    ICatalogUnitOfWork unitOfWork)
    : IEventHandler<StockChangedIntegrationEvent>
{
    public async Task HandleAsync(StockChangedIntegrationEvent evt, CancellationToken ct)
    {
        var product = await productsRepository.FindBySkuAsync(evt.SkuId, ct);

        if (product is null)
        {
            logger.LogWarning("Could not find product with SkuId {SkuId}", evt.SkuId);
            
            return;
        }

        var result = product.UpdateStock(evt.SkuId, evt.Stock);

        if (!result.IsSuccess)
        {
            logger.LogWarning("Problem occured trying to update product's sku stock. {Problem}", result.Problem.Reason);
            
            return;
        }

        await unitOfWork.SaveAsync(ct);
    }
}