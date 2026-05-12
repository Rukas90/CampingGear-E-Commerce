using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Options;

public static class ColorOption
{
    [SeededEntity] public static readonly OptionGroup OptionGroup = OptionGroup.Create("Color", "color");

    [SeededEntity] public static readonly Option Black = Option.Create(
        OptionGroup.Id,
        "Black",
        "black",
        previewType: PreviewType.Color,
        previewValue: "#000000");

    [SeededEntity] public static readonly Option White = Option.Create(
        OptionGroup.Id,
        "White",
        "white",
        previewType: PreviewType.Color,
        previewValue: "#FFFFFF");

    [SeededEntity] public static readonly Option Gray = Option.Create(
        OptionGroup.Id,
        "Gray",
        "gray",
        previewType: PreviewType.Color,
        previewValue: "#7F7F7F");

    [SeededEntity] public static readonly Option Red = Option.Create(
        OptionGroup.Id,
        "Red",
        "red",
        previewType: PreviewType.Color,
        previewValue: "#ED1C24");

    [SeededEntity] public static readonly Option Green = Option.Create(
        OptionGroup.Id,
        "Green",
        "green",
        previewType: PreviewType.Color,
        previewValue: "#22B14C");

    [SeededEntity] public static readonly Option Blue = Option.Create(
        OptionGroup.Id,
        "Blue",
        "blue",
        previewType: PreviewType.Color,
        previewValue: "#3244c1");

    [SeededEntity] public static readonly Option Yellow = Option.Create(
        OptionGroup.Id,
        "Yellow",
        "yellow",
        previewType: PreviewType.Color,
        previewValue: "#FFFD55");

    [SeededEntity] public static readonly Option Purple = Option.Create(
        OptionGroup.Id,
        "Purple",
        "purple",
        previewType: PreviewType.Color,
        previewValue: "#58135E");

    [SeededEntity] public static readonly Option DuskBlue = Option.Create(
        OptionGroup.Id,
        "Dusk Blue",
        "dusk-blue",
        previewType: PreviewType.Color,
        previewValue: "#1D57A6");

    [SeededEntity] public static readonly Option JetBlack = Option.Create(
        OptionGroup.Id,
        "Jet Black",
        "jet-black",
        previewType: PreviewType.Color,
        previewValue: "#363636");

    [SeededEntity] public static readonly Option StormGray = Option.Create(
        OptionGroup.Id,
        "Storm Gray",
        "storm-gray",
        previewType: PreviewType.Color,
        previewValue: "#D6D6D6");

    [SeededEntity] public static readonly Option BlazeOrange = Option.Create(
        OptionGroup.Id,
        "Blaze Orange",
        "blaze-orange",
        previewType: PreviewType.Color,
        previewValue: "#FA7D0E");

    [SeededEntity] public static readonly Option ChiliRed = Option.Create(
        OptionGroup.Id,
        "Chili Red",
        "chili-red",
        previewType: PreviewType.Color,
        previewValue: "#C44D4D");

    [SeededEntity] public static readonly Option Orange = Option.Create(
        OptionGroup.Id,
        "Orange",
        "orange",
        previewType: PreviewType.Color,
        previewValue: "#FFAF31");

    [SeededEntity] public static readonly Option Navy = Option.Create(
        OptionGroup.Id,
        "Navy",
        "navy",
        previewType: PreviewType.Color,
        previewValue: "#0C0D78");

    [SeededEntity] public static readonly Option Forest = Option.Create(
        OptionGroup.Id,
        "Forest",
        "forest",
        previewType: PreviewType.Color,
        previewValue: "#46732F");

    [SeededEntity] public static readonly Option Charcoal = Option.Create(
        OptionGroup.Id,
        "Charcoal",
        "charcoal",
        previewType: PreviewType.Color,
        previewValue: "#262626");

    [SeededEntity] public static readonly Option Olive = Option.Create(
        OptionGroup.Id,
        "Olive",
        "olive",
        previewType: PreviewType.Color,
        previewValue: "#5E781F");

    [SeededEntity] public static readonly Option SpruceGreen = Option.Create(
        OptionGroup.Id,
        "Spruce Green",
        "spruce-green",
        previewType: PreviewType.Color,
        previewValue: "#89C2A7");

    [SeededEntity] public static readonly Option DarkFoliageGreen = Option.Create(
        OptionGroup.Id,
        "Dark Foliage Green",
        "dark-foliage-green",
        previewType: PreviewType.Color,
        previewValue: "#354238");

    [SeededEntity] public static readonly Option RangerGreen = Option.Create(
        OptionGroup.Id,
        "Ranger Green",
        "ranger-green",
        previewType: PreviewType.Color,
        previewValue: "#606B54");

    [SeededEntity] public static readonly Option Brown = Option.Create(
        OptionGroup.Id,
        "Brown",
        "brown",
        previewType: PreviewType.Color,
        previewValue: "#635946");

    [SeededEntity] public static readonly Option AutumnOrange = Option.Create(
        OptionGroup.Id,
        "Autumn Orange",
        "autumn-orange",
        previewType: PreviewType.Color,
        previewValue: "#D6782C");

    [SeededEntity] public static readonly Option OceanBlue = Option.Create(
        OptionGroup.Id,
        "Ocean Blue",
        "ocean-blue",
        previewType: PreviewType.Color,
        previewValue: "#225180");

    [SeededEntity] public static readonly Option OliveGreen = Option.Create(
        OptionGroup.Id,
        "Olive Green",
        "olive-green",
        previewType: PreviewType.Color,
        previewValue: "#819147");

    [SeededEntity] public static readonly Option ShadowPineCamo = Option.Create(
        OptionGroup.Id,
        "Shadow Pine Camo",
        "shadow-pine-camo",
        previewType: PreviewType.Image,
        previewValue: "/options/color/shadow-pine-camo.webp");

    [SeededEntity] public static readonly Option LeafyWoodsCamo = Option.Create(
        OptionGroup.Id,
        "Leafy Woods Camo",
        "leafy-woods-camo",
        previewType: PreviewType.Image,
        previewValue: "/options/color/leafy-woods-camo.webp");

    [SeededEntity] public static readonly Option SnowDayCamo = Option.Create(
        OptionGroup.Id,
        "Snow Day Camo",
        "snow-day-camo",
        previewType: PreviewType.Image,
        previewValue: "/options/color/snow-day-camo.webp");
}