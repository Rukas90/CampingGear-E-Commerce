using TrailStore.Api.Common.Dto;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Checkout.Dto;

public class CheckoutShippingDto
{
    public PostalAddressDto? Address { get; set; }
    public Id<ShippingMethod>? SelectedMethodId { get; init; }
}