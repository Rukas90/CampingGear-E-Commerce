using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Options;

// ReSharper disable UnusedType.Global
public static class InteriorOption
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Interior", "interior");

    [SeededEntity] public static readonly Option Regular = Option.Create(
        OptionGroup.Id,
        "Regular", "regular");

    [SeededEntity] public static readonly Option Solid = Option.Create(
        OptionGroup.Id,
        "Solid", "solid", 1);
}