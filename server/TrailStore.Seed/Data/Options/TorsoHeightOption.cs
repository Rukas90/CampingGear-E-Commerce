using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

public static class TorsoHeightOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Torso Height", slug: "torso-height");
        
    [SeededEntity]
    public static readonly Option Short = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Short", slug: "short", sortOrder: 0);
        
    [SeededEntity]
    public static readonly Option Medium = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Medium", slug: "medium", sortOrder: 1);
        
    [SeededEntity]
    public static readonly Option Tall = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Tall", slug: "tall", sortOrder: 2);
}