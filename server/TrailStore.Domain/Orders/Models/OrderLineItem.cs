using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Orders.Models;

public readonly record struct OrderLineItem(Id<Sku> SkuId, string SkuCode, decimal UnitPrice, int Quantity);