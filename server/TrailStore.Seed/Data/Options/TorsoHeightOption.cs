using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Options;

public static class TorsoHeightOption
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Torso Height", "torso-height");

    [SeededEntity] public static readonly Option Short = Option.Create(
        OptionGroup.Id,
        "Short", "short", 0);

    [SeededEntity] public static readonly Option Medium = Option.Create(
        OptionGroup.Id,
        "Medium", "medium", 1);

    [SeededEntity] public static readonly Option Tall = Option.Create(
        OptionGroup.Id,
        "Tall", "tall", 2);
}