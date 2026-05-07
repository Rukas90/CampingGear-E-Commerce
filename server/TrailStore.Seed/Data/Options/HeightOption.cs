using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

public static class HeightOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Height", slug: "height");
    
    [SeededEntity]
    public static readonly Option Short = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Short", slug: "short", sortOrder: 0);
        
    [SeededEntity]
    public static readonly Option Regular = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Regular", slug: "regular", sortOrder: 1);
        
    [SeededEntity]
    public static readonly Option Medium = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Medium", slug: "medium", sortOrder: 2);
        
    [SeededEntity]
    public static readonly Option Tall = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Tall", slug: "tall", sortOrder: 3);
}