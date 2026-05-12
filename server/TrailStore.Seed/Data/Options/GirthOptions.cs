using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Options;

// ReSharper disable UnusedType.Global
public static class GirthOptions
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Girth", "girth");

    [SeededEntity] public static readonly Option Slim = Option.Create(
        OptionGroup.Id,
        "Slim", "slim", 0);

    [SeededEntity] public static readonly Option Regular = Option.Create(
        OptionGroup.Id,
        "Regular", "regular", 1);

    [SeededEntity] public static readonly Option Broad = Option.Create(
        OptionGroup.Id,
        "Broad", "broad", 2);
}