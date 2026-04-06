using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

public class SizeOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Size");
    
    [SeededEntity]
    public static readonly Option Small = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Small", slug: "small");
        
    [SeededEntity]
    public static readonly Option Regular = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Regular", slug: "regular");
        
    [SeededEntity]
    public static readonly Option RegularWide = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Regular Wide", slug: "regular-wide");
        
    [SeededEntity]
    public static readonly Option ShortRegular = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Short Regular", slug: "short-regular");
        
    [SeededEntity]
    public static readonly Option Medium = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Medium", slug: "medium");
        
    [SeededEntity]
    public static readonly Option Large = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Large", slug: "large");
        
    [SeededEntity]
    public static readonly Option XL = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "XL", slug: "xl");
}