using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

public class TorsoHeightOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Torso Height");
        
    [SeededEntity]
    public static readonly Option Short = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Short", slug: "short");
        
    [SeededEntity]
    public static readonly Option Medium = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Medium", slug: "medium");
        
    [SeededEntity]
    public static readonly Option Tall = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Tall", slug: "tall");
}