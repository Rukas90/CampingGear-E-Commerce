using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Shipping;

public sealed class ShippingMethod : AggregateRoot<ShippingMethod>
{
    public required Id<ShippingZone> ZoneId { get; init; }
    public required string Code { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal FlatFee { get; init; }
    public required decimal FreeShippingThreshold { get; init; }

    public ShippingZone Zone { get; private set; } = null!;

    public static ShippingMethod Create(Id<ShippingZone> zoneId, string code, string name, string description, decimal flatFee)
        => new()
        {
            Id = Id<ShippingMethod>.New(),
            ZoneId = zoneId,
            Code = code,
            Name = name,
            Description = description,
            FlatFee = flatFee,
            FreeShippingThreshold = 100m
        };
}