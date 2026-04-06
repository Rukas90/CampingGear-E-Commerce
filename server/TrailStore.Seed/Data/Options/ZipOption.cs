using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

public class ZipOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Zip");
    
    [SeededEntity]
    public static readonly Option Left = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Left", slug: "left");
        
    [SeededEntity]
    public static readonly Option Right = Option.Create(
        optionGroupId: OptionGroup.Id,
        name: "Right", slug: "right");
}