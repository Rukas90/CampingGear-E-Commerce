using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Options;

// ReSharper disable UnusedType.Global
public static class PoleSetOption
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Pole Set", "pole-set");

    [SeededEntity] public static readonly Option Aluminum = Option.Create(
        OptionGroup.Id,
        "Aluminum", "aluminum", 0);

    [SeededEntity] public static readonly Option Carbon = Option.Create(
        OptionGroup.Id,
        "Carbon", "carbon", 1);

    [SeededEntity] public static readonly Option CarbonShort = Option.Create(
        OptionGroup.Id,
        "Carbon Short", "carbon-short", 2);
}