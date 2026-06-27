using TrailStore.Ordering.Domain.Orders;

namespace TrailStore.Ordering.Domain.Checkout;

public class CheckoutBilling
{
    public bool AsShippingAddress { get; init; }
    public BillingAddress? Address { get; init; }
}