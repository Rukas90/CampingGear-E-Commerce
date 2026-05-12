using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data;

public static class CategoryGroups
{
    [SeededEntity] public static readonly CategoryGroup SleepSystem = CategoryGroup.Create(
        "Sleep System",
        "sleep-system",
        0);

    [SeededEntity] public static readonly CategoryGroup NavigationSafety = CategoryGroup.Create(
        "Navigation & Safety",
        "navigation-safety",
        1);

    [SeededEntity] public static readonly CategoryGroup HikingCamping = CategoryGroup.Create(
        "Hiking & Camping",
        "hiking-camping",
        2);

    [SeededEntity] public static readonly CategoryGroup ApparelProtection = CategoryGroup.Create(
        "Apparel & Protection",
        "apparel-protection",
        4);
}