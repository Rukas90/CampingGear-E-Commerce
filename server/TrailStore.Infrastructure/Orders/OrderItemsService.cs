using TrailStore.Domain.Carts.Models;
using TrailStore.Domain.Orders.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.Skus.Interfaces;
using TrailStore.Domain.Skus.Specifications;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Orders;

[AppService<IOrderItemsService>]
public class OrderItemsService(
    IOrderItemRepository orderItemRepository, 
    ISkuRepository skuRepository) 
    : IOrderItemsService
{
    public async Task CreateOrderItems(Id<Order> orderId, CartLineItem[] entries, CancellationToken ct)
    {
        var specification = SkuSpecificationBuilder.BuildFromCodes(
            entries.Select(e => e.Code).ToArray());

        var skus = await skuRepository.ListAllAsync(specification, sku => sku, ct);
        
        var items = entries.Select(entry =>
        {
            var sku = skus.First(s => s.Code.Equals(entry.Code, StringComparison.InvariantCultureIgnoreCase));
            return OrderItem.Create(orderId, sku.Id, entry.Quantity, sku.UnitPrice, 0);
        }).ToArray();

        await orderItemRepository.AddItemsAsync(items, ct);
    }
}