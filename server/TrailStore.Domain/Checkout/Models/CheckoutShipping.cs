using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Checkout.Models;

public class CheckoutShipping
{
    public PostalAddress? Address { get; set; }
    public Id<ShippingMethod>? SelectedMethodId { get; init; }
}