using TrailStore.Api.Shipping.Dto;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Api.Shipping.Mapping;

public static class ShippingMethodMapping
{
    public static List<ShippingMethodDto> ToDto(this List<ShippingMethod> methods)
        => methods.Select(ToDto).ToList();
    
    public static ShippingMethodDto ToDto(this ShippingMethod shippingMethod)
        => new()
        {
            Id = shippingMethod.Id,
            Name = shippingMethod.Name,
            Description = shippingMethod.Description,
            FlatFee = shippingMethod.FlatFee,
            FreeShippingThreshold = shippingMethod.FreeShippingThreshold
        };
}