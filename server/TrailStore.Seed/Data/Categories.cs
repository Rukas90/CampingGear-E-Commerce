using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data;

// ReSharper disable All

public class Categories
{
    [SeededEntity]
    public static readonly Category HandheldGps = Category.Create(
        groupId:     CategoryGroups.NavigationSafety.Id,
        name:        "Handheld GPS", 
        slug:        "handheld-gps", 
        imageUrl:    "products/gpsmap-67-xl.webp");
        
    [SeededEntity]
    public static readonly Category SleepingBags = Category.Create(
        groupId:     CategoryGroups.SleepSystem.Id,
        name:        "Sleeping Bags", 
        slug:        "sleeping-bags", 
        imageUrl:    "products/western-mountaineering-alpinlite-20.webp");
        
    [SeededEntity]
    public static readonly Category SleepingMats = Category.Create(
        groupId:     CategoryGroups.SleepSystem.Id,
        name:        "Sleeping Mats", 
        slug:        "sleeping-mats", 
        imageUrl:    "products/thermarest-neoair-xlite.webp");
        
    [SeededEntity]
    public static readonly Category Quilts = Category.Create(
        groupId:     CategoryGroups.SleepSystem.Id,
        name:        "Quilts", 
        slug:        "quilts", 
        imageUrl:    "products/zpacks-summer-quilt--winter-liner-blu.webp");
        
    [SeededEntity]
    public static readonly Category Tents = Category.Create(
        groupId:     CategoryGroups.SleepSystem.Id,
        name:        "Tents", 
        slug:        "tents", 
        imageUrl:    "products/durston-x-mid-pro-1---3.webp");
        
    [SeededEntity]
    public static readonly Category Backpacks = Category.Create(
        groupId:     CategoryGroups.HikingCamping.Id,
        name:        "Backpacks", 
        slug:        "backpacks", 
        imageUrl:    "products/gregory-baltoro-75-man.webp");
        
    [SeededEntity]
    public static readonly Category Sunglasses = Category.Create(
        groupId:     CategoryGroups.ApparelProtection.Id,
        name:        "Sunglasses", 
        slug:        "sunglasses", 
        imageUrl:    "products/ombraz-refugio-armless.webp");
        
    [SeededEntity]
    public static readonly Category HydrationFiltration = Category.Create(
        groupId:     CategoryGroups.HikingCamping.Id,
        name:        "Hydration/Filtration", 
        slug:        "hydration-filtration",
        imageUrl:    "products/gossamer-gear-bottle-rocket.webp");
        
    [SeededEntity]
    public static readonly Category BivysLiners = Category.Create(
        groupId:     CategoryGroups.SleepSystem.Id,
        name:        "Bivys & Liners", 
        slug:        "bivys-liners",
        imageUrl:    "products/hyperlite-mountain-gear-bug-bivy.webp");
        
    [SeededEntity]
    public static readonly Category FireStarters = Category.Create(
        groupId:     CategoryGroups.HikingCamping.Id,
        name:        "Fire Starters", 
        slug:        "fire-starters",
        imageUrl:    "products/vargo-ultimate-fire-starter-blaze.webp");
        
    [SeededEntity]
    public static readonly Category Cutlery = Category.Create(
        groupId:     CategoryGroups.KitchenCooking.Id,
        name:        "Cutlery", 
        slug:        "cutlery",
        imageUrl:    "products/vargo-spork-ulv.webp");
        
    [SeededEntity]
    public static readonly Category StuffSacks = Category.Create(
        groupId:     CategoryGroups.HikingCamping.Id,
        name:        "Stuff Sacks", 
        slug:        "stuff-sacks",
        imageUrl:    "products/hyperlite-mountain-gear-pods.webp");
        
    [SeededEntity]
    public static readonly Category TrekkingPoles = Category.Create(
        groupId:     CategoryGroups.HikingCamping.Id,
        name:        "Trekking Poles", 
        slug:        "trekking-poles",
        imageUrl:    "products/durston-incline-trekking-poles.webp");
        
    [SeededEntity]
    public static readonly Category Stoves = Category.Create(
        groupId:     CategoryGroups.KitchenCooking.Id,
        name:        "Stoves", 
        slug:        "stoves",
        imageUrl:    "products/msr-pocket-rocket-2-stove.webp");
        
    [SeededEntity]
    public static readonly Category CareProtection = Category.Create(
        groupId:     CategoryGroups.ApparelProtection.Id,
        name:        "Care & Protection", 
        slug:        "care-protection",
        imageUrl:    "products/zpacks-arc-backpack-belt.webp");
        
    [SeededEntity]
    public static readonly Category PotsPans = Category.Create(
        groupId:     CategoryGroups.KitchenCooking.Id,
        name:        "Pots & Pans", 
        slug:        "pots-pans",
        imageUrl:    "products/vargo-titanium-bot--700.webp");
        
    [SeededEntity]
    public static readonly Category Accessories = Category.Create(
        groupId:     CategoryGroups.HikingCamping.Id,
        name:        "Accessories", 
        slug:        "accessories",
        imageUrl:    "products/thermarest-z-seat-sol.webp");
}