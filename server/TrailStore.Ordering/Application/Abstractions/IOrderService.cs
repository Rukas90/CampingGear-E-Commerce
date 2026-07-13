using TrailStore.Basket.Contracts.Carts;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Abstractions;

public interface IOrderService
{
    Order CreateOrder(CreateOrderRequest request);

    Task<Result<CreateOrderRequest>> BuildOrderCreationInput(Id<CartRef> cartId,
        ValidatedCheckoutInformation information, CancellationToken ct);
}