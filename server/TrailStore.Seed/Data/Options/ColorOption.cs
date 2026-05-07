using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Options;

public static class ColorOption
{
    [SeededEntity]
    public static readonly OptionGroup OptionGroup = OptionGroup.Create(name: "Color", slug: "color");

    [SeededEntity]
    public static readonly Option Black = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Black",
        slug:          "black",
        previewType:   PreviewType.Color,
        previewValue:  "#000000");
    
    [SeededEntity]
    public static readonly Option White = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "White",
        slug:          "white",
        previewType:   PreviewType.Color,
        previewValue:  "#FFFFFF");
    
    [SeededEntity]
    public static readonly Option Gray = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Gray",
        slug:          "gray",
        previewType:   PreviewType.Color,
        previewValue:  "#7F7F7F");
    
    [SeededEntity]
    public static readonly Option Red = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Red",
        slug:          "red",
        previewType:   PreviewType.Color,
        previewValue:  "#ED1C24");
    
    [SeededEntity]
    public static readonly Option Green = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Green",
        slug:          "green",
        previewType:   PreviewType.Color,
        previewValue:  "#22B14C");
    
    [SeededEntity]
    public static readonly Option Blue = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Blue",
        slug:          "blue",
        previewType:   PreviewType.Color,
        previewValue:  "#3244c1");
    
    [SeededEntity]
    public static readonly Option Yellow = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Yellow",
        slug:          "yellow",
        previewType:   PreviewType.Color,
        previewValue:  "#FFFD55");
    
    [SeededEntity]
    public static readonly Option Purple = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Purple",
        slug:          "purple",
        previewType:   PreviewType.Color,
        previewValue:  "#58135E");
    
    [SeededEntity]
    public static readonly Option DuskBlue = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Dusk Blue",
        slug:          "dusk-blue",
        previewType:   PreviewType.Color,
        previewValue:  "#1D57A6");
    
    [SeededEntity]
    public static readonly Option JetBlack = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Jet Black",
        slug:          "jet-black",
        previewType:   PreviewType.Color,
        previewValue:  "#363636");
    
    [SeededEntity]
    public static readonly Option StormGray = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Storm Gray",
        slug:          "storm-gray",
        previewType:   PreviewType.Color,
        previewValue:  "#D6D6D6");
    
    [SeededEntity]
    public static readonly Option BlazeOrange = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Blaze Orange",
        slug:          "blaze-orange",
        previewType:   PreviewType.Color,
        previewValue:  "#FA7D0E");
    
    [SeededEntity]
    public static readonly Option ChiliRed = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Chili Red",
        slug:          "chili-red",
        previewType:   PreviewType.Color,
        previewValue:  "#C44D4D");
    
    [SeededEntity]
    public static readonly Option Orange = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Orange",
        slug:          "orange",
        previewType:   PreviewType.Color,
        previewValue:  "#FFAF31");
    
    [SeededEntity]
    public static readonly Option Navy = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Navy",
        slug:          "navy",
        previewType:   PreviewType.Color,
        previewValue:  "#0C0D78");
    
    [SeededEntity]
    public static readonly Option Forest = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Forest",
        slug:          "forest",
        previewType:   PreviewType.Color,
        previewValue:  "#46732F");
    
    [SeededEntity]
    public static readonly Option Charcoal = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Charcoal",
        slug:          "charcoal",
        previewType:   PreviewType.Color,
        previewValue:  "#262626");
    
    [SeededEntity]
    public static readonly Option Olive = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Olive",
        slug:          "olive",
        previewType:   PreviewType.Color,
        previewValue:  "#5E781F");
    
    [SeededEntity]
    public static readonly Option SpruceGreen = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Spruce Green",
        slug:          "spruce-green",
        previewType:   PreviewType.Color,
        previewValue:  "#89C2A7");
    
    [SeededEntity]
    public static readonly Option BushwackCamo = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Bushwack Camo",
        slug:          "bushwack-camo",
        previewType:   PreviewType.Image,
        previewValue:  "/options/color/bushwack-camo.webp");
    
    [SeededEntity]
    public static readonly Option ShadowPineCamo = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Shadow Pine Camo",
        slug:          "shadow-pine-camo",
        previewType:   PreviewType.Image,
        previewValue:  "/options/color/shadow-pine-camo.webp");
    
    [SeededEntity]
    public static readonly Option DarkFoliageGreen = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Dark Foliage Green",
        slug:          "dark-foliage-green",
        previewType:   PreviewType.Color,
        previewValue:  "#003f1b");
    
    [SeededEntity]
    public static readonly Option SnowDayCamo = Option.Create(
        optionGroupId: OptionGroup.Id,
        name:          "Snow Day Camo",
        slug:          "snow-day-camo",
        previewType:   PreviewType.Image,
        previewValue:  "/options/color/snow-day-camo.webp");
}