using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Checkout.Dto;

public class UpdateShippingMethodRequest
{
    public Id<ShippingMethod> ShippingMethodId { get; init; }
}