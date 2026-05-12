using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Options;

public static class WidthOption
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Width", "width");

    [SeededEntity] public static readonly Option Narrow = Option.Create(
        OptionGroup.Id,
        "Narrow", "narrow");

    [SeededEntity] public static readonly Option Regular = Option.Create(
        OptionGroup.Id,
        "Regular", "regular", 1);

    [SeededEntity] public static readonly Option Medium = Option.Create(
        OptionGroup.Id,
        "Medium", "medium", 2);

    [SeededEntity] public static readonly Option Wide = Option.Create(
        OptionGroup.Id,
        "Wide", "wide", 3);
}