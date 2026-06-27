using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Abstractions;

public interface ICheckoutService
{
    Task<ShippingMethod?> GetShippingMethod(
        Id<ShippingMethod>? currentMethodId, PostalAddress? shippingAddress, CancellationToken ct);

    Task<ShippingMethod?> ValidateCheckoutShipping(
        CheckoutSession checkoutSession, CancellationToken ct);
}