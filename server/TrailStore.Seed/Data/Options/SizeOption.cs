using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

public static class SizeOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Size", slug: "size");
    
    [SeededEntity]
    public static readonly Option Small = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Small", slug: "small", sortOrder: 0);
        
    [SeededEntity]
    public static readonly Option Regular = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Regular", slug: "regular", sortOrder: 1);
        
    [SeededEntity]
    public static readonly Option Medium = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Medium", slug: "medium", sortOrder: 2);
        
    [SeededEntity]
    public static readonly Option Large = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Large", slug: "large", sortOrder: 3);
        
    [SeededEntity]
    public static readonly Option XL = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "XL", slug: "xl", sortOrder: 4);
    
    [SeededEntity]
    public static readonly Option XXL = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "2XL", slug: "2xl", sortOrder: 5);
}