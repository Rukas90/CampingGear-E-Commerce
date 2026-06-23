using TrailStore.Catalog.Domain.Options;
using TrailStore.Shared.Seeding;

namespace TrailStore.Catalog.Seed.Options;

public static class HeightOption
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Height", "height");

    [SeededEntity] public static readonly Option Short = Option.Create(
        OptionGroup.Id,
        "Short", "short");

    [SeededEntity] public static readonly Option Regular = Option.Create(
        OptionGroup.Id,
        "Regular", "regular", 1);

    [SeededEntity] public static readonly Option Medium = Option.Create(
        OptionGroup.Id,
        "Medium", "medium", 2);

    [SeededEntity] public static readonly Option Tall = Option.Create(
        OptionGroup.Id,
        "Tall", "tall", 3);
}