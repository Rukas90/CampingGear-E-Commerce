using TrailStore.Basket.Domain.Carts;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Endpoints.UpdateCartItemQuantity;

public sealed class UpdateCartItemQuantityRequest
{
    public Id<CartItem> ItemId { get; init; }
    public int Quantity { get; init; }
}