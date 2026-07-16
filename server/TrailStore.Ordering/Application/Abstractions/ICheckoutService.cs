using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Abstractions;

public interface ICheckoutService
{
    Task<ShippingMethod?> GetShippingMethod(
        Id<ShippingMethod>? currentMethodId, PostalAddress? shippingAddress, CancellationToken ct);
    
    Task<Result<Order>> CheckoutToOrder(
        Id<CartRef> cartId, ValidatedCheckoutInformation validatedInformation, CancellationToken ct);

    Task PersistCheckoutDetails(
        Id<UserRef> UserId, ValidatedCheckoutInformation validatedInformation, CancellationToken ct);

    Task ClearAnyPersistedCheckoutDetails(Id<UserRef> UserId, CancellationToken ct);
}