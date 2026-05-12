using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Options;

public static class SizeOption
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Size", "size");

    [SeededEntity] public static readonly Option Small = Option.Create(
        OptionGroup.Id,
        "Small", "small");

    [SeededEntity] public static readonly Option Regular = Option.Create(
        OptionGroup.Id,
        "Regular", "regular", 1);

    [SeededEntity] public static readonly Option Medium = Option.Create(
        OptionGroup.Id,
        "Medium", "medium", 2);

    [SeededEntity] public static readonly Option Large = Option.Create(
        OptionGroup.Id,
        "Large", "large", 3);

    [SeededEntity] public static readonly Option XL = Option.Create(
        OptionGroup.Id,
        "XL", "xl", 4);

    [SeededEntity] public static readonly Option XXL = Option.Create(
        OptionGroup.Id,
        "2XL", "2xl", 5);
}