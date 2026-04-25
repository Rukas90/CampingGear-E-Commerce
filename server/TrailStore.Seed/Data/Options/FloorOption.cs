using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

// ReSharper disable UnusedType.Global

public class FloorOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Floor", slug: "floor");
    
    [SeededEntity]
    public static readonly Option Woven = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Woven", slug: "woven");
    
    [SeededEntity]
    public static readonly Option Dyneema = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Dyneema", slug: "dyneema");
}