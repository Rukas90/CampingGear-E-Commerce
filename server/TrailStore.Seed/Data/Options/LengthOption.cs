using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

public class LengthOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Length", slug: "length");
    
    [SeededEntity]
    public static readonly Option Cm165 = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "5'6\" (165 cm)", slug: "165cm");
    
    [SeededEntity]
    public static readonly Option Cm180 = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "6'0\" (180 cm)", slug: "180cm");
    
    [SeededEntity]
    public static readonly Option Cm200 = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "6'6\" (200 cm)", slug: "200cm");
}