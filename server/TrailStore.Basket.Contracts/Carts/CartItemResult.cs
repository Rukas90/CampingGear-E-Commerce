using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Contracts.Carts;

public class CartItemResult
{
    public required Id<SkuRef> SkuId { get; init; }
    public required string SkuCode { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Quantity { get; init; }
}