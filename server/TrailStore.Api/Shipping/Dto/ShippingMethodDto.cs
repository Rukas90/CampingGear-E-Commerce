using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Shipping.Dto;

public class ShippingMethodDto
{
    public required Id<ShippingMethod> Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal FlatFee { get; set; }
    public required decimal FreeShippingThreshold { get; set; }
}