using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

// ReSharper disable UnusedType.Global

public static class PoleSetOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Pole Set", slug: "pole-set");
    
    [SeededEntity]
    public static readonly Option Aluminum = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Aluminum", slug: "aluminum");
    
    [SeededEntity]
    public static readonly Option Carbon = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Carbon", slug: "carbon");
    
    [SeededEntity]
    public static readonly Option CarbonShort = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Carbon Short", slug: "carbon-short");
}