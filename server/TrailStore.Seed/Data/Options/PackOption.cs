using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

// ReSharper disable UnusedType.Global

public static class PackOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Pack", slug: "pack");

    [SeededEntity]
    public static readonly Option Single = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Single", slug: "single", sortOrder: 0);

    [SeededEntity]
    public static readonly Option Pack6 = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "6-Pack", slug: "6-pack", sortOrder: 1);

    [SeededEntity]
    public static readonly Option Pack10 = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "10-Pack", slug: "10-pack", sortOrder: 2);
}