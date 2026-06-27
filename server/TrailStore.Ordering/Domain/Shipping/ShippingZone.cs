using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Shipping;

public sealed class ShippingZone : IModel<ShippingZone>
{
    public required Id<ShippingZone> Id { get; init; }
    public required string Name { get; init; }
    public required string[] CountryCodes { get; init; }

    public ICollection<ShippingMethod> Methods { get; private set; } = [];

    public static ShippingZone Create(string name, params string[] countryCodes)
        => new()
        {
            Id = Id<ShippingZone>.New(),
            Name = name,
            CountryCodes = countryCodes
        };
}