using TrailStore.Ordering.Domain.Countries.Models;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Checkout;

public sealed record ValidatedCheckoutInformation(
    string EmailAddress,
    Country Country,
    ShippingAddress ShippingAddress,
    BillingAddress BillingAddress,
    Id<ShippingMethod> ShippingMethodId,
    bool ShippingAddressAsBillingAddress
);