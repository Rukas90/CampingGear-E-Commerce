using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Endpoints.AddToCart;

public sealed class AddToCartRequest
{
    public Id<SkuRef> SkuId { get; set; }
    public int Quantity { get; set; }
}