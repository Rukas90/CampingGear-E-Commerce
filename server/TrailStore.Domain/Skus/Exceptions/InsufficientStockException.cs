using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Skus.Exceptions;

public class InsufficientStockException(Id<Sku> skuId) : Exception($"Insufficient stock for SKU {skuId}")
{
    public Id<Sku> SkuId { get; } = skuId;
}