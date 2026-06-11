using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Skus.Exceptions;

public class SkuNotFoundException(Id<Sku> skuId) : Exception($"SKU {skuId} not found")
{
    public Id<Sku> SkuId { get; } = skuId;
}