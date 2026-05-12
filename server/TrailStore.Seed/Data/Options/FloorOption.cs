using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Options;

// ReSharper disable UnusedType.Global
public static class FloorOption
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Floor", "floor");

    [SeededEntity] public static readonly Option Woven = Option.Create(
        OptionGroup.Id,
        "Woven", "woven");

    [SeededEntity] public static readonly Option Dyneema = Option.Create(
        OptionGroup.Id,
        "Dyneema", "dyneema");
}