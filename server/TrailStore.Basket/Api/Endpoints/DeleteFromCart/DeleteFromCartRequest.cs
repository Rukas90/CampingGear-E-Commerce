using TrailStore.Basket.Domain.Carts;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Endpoints.DeleteFromCart;

public sealed class DeleteFromCartRequest
{
    public Id<CartItem> ItemId { get; init; }
}