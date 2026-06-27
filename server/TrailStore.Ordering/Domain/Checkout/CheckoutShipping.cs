using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Checkout;

public class CheckoutShipping
{
    public PostalAddress? Address { get; set; }
    public Id<ShippingMethod>? SelectedMethodId { get; init; }
}