using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Ordering.Domain.Financials;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public sealed record OrderLineItem(
    Id<SkuRef> SkuId,
    string BrandName,
    string ProductName,
    string VariantLine,
    decimal UnitPrice,
    int Quantity,
    string? ThumbnailUrl,
    LineFinancials Financials);