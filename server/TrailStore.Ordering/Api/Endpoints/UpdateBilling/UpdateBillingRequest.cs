using TrailStore.Ordering.Api.Common.PostalAddress;

namespace TrailStore.Ordering.Api.Endpoints.UpdateBilling;

public class UpdateBillingRequest
{
    public PostalAddressRequest? Address { get; init; }
    public bool? AsShippingAddress { get; init; }
    
}