using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Options;

public static class LengthOption
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Length", "length");

    [SeededEntity] public static readonly Option Cm165 = Option.Create(
        OptionGroup.Id,
        "5'6\" (165 cm)", "165cm");

    [SeededEntity] public static readonly Option Cm180 = Option.Create(
        OptionGroup.Id,
        "6'0\" (180 cm)", "180cm", 1);

    [SeededEntity] public static readonly Option Cm200 = Option.Create(
        OptionGroup.Id,
        "6'6\" (200 cm)", "200cm", 2);
}