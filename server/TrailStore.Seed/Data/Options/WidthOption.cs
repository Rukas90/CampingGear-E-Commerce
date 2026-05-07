using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

public static class WidthOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Width", slug: "width");
        
    [SeededEntity]
    public static readonly Option Narrow = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Narrow", slug: "narrow", sortOrder: 0);
    
    [SeededEntity]
    public static readonly Option Regular = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Regular", slug: "regular", sortOrder: 1);
        
    [SeededEntity]
    public static readonly Option Medium = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Medium", slug: "medium", sortOrder: 2);
        
    [SeededEntity]
    public static readonly Option Wide = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Wide", slug: "wide", sortOrder: 3);
}