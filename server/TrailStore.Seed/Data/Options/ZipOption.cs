using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

public static class ZipOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Zip", slug: "zip");
    
    [SeededEntity]
    public static readonly Option Left = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Left", slug: "left", sortOrder: 0);
        
    [SeededEntity]
    public static readonly Option Right = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Right", slug: "right", sortOrder: 1);
}