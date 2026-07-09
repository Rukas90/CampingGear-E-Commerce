using TrailStore.Ordering.Api.Common.PostalAddress;

namespace TrailStore.Ordering.Api.Checkouts;

public class CheckoutShippingResponse
{
    public PostalAddressResponse? Address { get; set; }
    public Guid? SelectedMethodId { get; init; }
}