using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

// ReSharper disable UnusedType.Global

public static class GirthOptions
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Girth", slug: "girth");
    
    [SeededEntity]
    public static readonly Option Slim = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Slim", slug: "slim", sortOrder: 0);
    
    [SeededEntity]
    public static readonly Option Regular = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Regular", slug: "regular", sortOrder: 1);
        
    [SeededEntity]
    public static readonly Option Broad = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Broad", slug: "broad", sortOrder: 2);
}