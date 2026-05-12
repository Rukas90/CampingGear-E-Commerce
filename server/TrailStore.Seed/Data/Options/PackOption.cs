using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Options;

// ReSharper disable UnusedType.Global
public static class PackOption
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Pack", "pack");

    [SeededEntity] public static readonly Option Single = Option.Create(
        OptionGroup.Id,
        "Single", "single", 0);

    [SeededEntity] public static readonly Option Pack6 = Option.Create(
        OptionGroup.Id,
        "6-Pack", "6-pack", 1);

    [SeededEntity] public static readonly Option Pack10 = Option.Create(
        OptionGroup.Id,
        "10-Pack", "10-pack", 2);
}