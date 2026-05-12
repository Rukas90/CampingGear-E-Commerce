using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Options;

public static class ZipOption
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Zip", "zip");

    [SeededEntity] public static readonly Option Left = Option.Create(
        OptionGroup.Id,
        "Left", "left");

    [SeededEntity] public static readonly Option Right = Option.Create(
        OptionGroup.Id,
        "Right", "right", 1);
}