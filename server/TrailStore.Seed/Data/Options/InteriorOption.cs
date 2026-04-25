using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

// ReSharper disable UnusedType.Global

public class InteriorOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Interior", slug: "interior");
    
    [SeededEntity]
    public static readonly Option Regular = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Regular", slug: "regular");
    
    [SeededEntity]
    public static readonly Option Solid = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Solid", slug: "solid");
}