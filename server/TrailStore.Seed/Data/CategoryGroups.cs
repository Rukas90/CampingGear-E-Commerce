using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data;

public static class CategoryGroups
{
    [SeededEntity]
    public static readonly CategoryGroup SleepSystem = CategoryGroup.Create(
        name:      "Sleep System",
        slug:      "sleep-system",
        sortOrder: 0);
    
    [SeededEntity]
    public static readonly CategoryGroup NavigationSafety = CategoryGroup.Create(
        name:      "Navigation & Safety",
        slug:      "navigation-safety",
        sortOrder: 1);
    
    [SeededEntity]
    public static readonly CategoryGroup HikingCamping = CategoryGroup.Create(
        name:      "Hiking & Camping",
        slug:      "hiking-camping",
        sortOrder: 2);
    
    [SeededEntity]
    public static readonly CategoryGroup KitchenCooking = CategoryGroup.Create(
        name:      "Kitchen & Cooking",
        slug:      "kitchen-cooking",
        sortOrder: 3);
    
    [SeededEntity]
    public static readonly CategoryGroup ApparelProtection = CategoryGroup.Create(
        name:      "Apparel & Protection",
        slug:      "apparel-protection",
        sortOrder: 4);
}