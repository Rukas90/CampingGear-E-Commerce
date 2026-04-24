using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data;

// ReSharper disable All

public class Categories
{
    [SeededEntity]
    public static readonly Category HandheldGps = Category.Create(
        name:        "Handheld GPS", 
        slug:        "handheld-gps", 
        imageUrl:    "products/gpsmap-67-xl.webp");
        
    [SeededEntity]
    public static readonly Category SleepingBags = Category.Create(
        name:        "Sleeping Bags", 
        slug:        "sleeping-bags", 
        imageUrl:    "products/western-mountaineering-alpinlite-20.webp");
        
    [SeededEntity]
    public static readonly Category SleepingMats = Category.Create(
        name:        "Sleeping Mats", 
        slug:        "sleeping-mats", 
        imageUrl:    "products/thermarest-neoair-xlite.webp");
        
    [SeededEntity]
    public static readonly Category Quilts = Category.Create(
        name:        "Quilts", 
        slug:        "quilts", 
        imageUrl:    "products/zpacks-summer-quilt--winter-liner.webp");
        
    [SeededEntity]
    public static readonly Category Tents = Category.Create(
        name:        "Tents", 
        slug:        "tents", 
        imageUrl:    "products/durston-x-mid-pro-1---3.webp");
        
    [SeededEntity]
    public static readonly Category Backpacks = Category.Create(
        name:        "Backpacks", 
        slug:        "backpacks", 
        imageUrl:    "products/gregory-baltoro-75-man.webp");
        
    [SeededEntity]
    public static readonly Category Sunglasses = Category.Create(
        name:        "Sunglasses", 
        slug:        "sunglasses", 
        imageUrl:    "products/ombraz-refugio-armless.webp");
        
    [SeededEntity]
    public static readonly Category HydrationFiltration = Category.Create(
        name:        "Hydration/Filtration", 
        slug:        "hydration-filtration",
        imageUrl:    "products/gossamer-gear-bottle-rocket.webp");
        
    [SeededEntity]
    public static readonly Category BivysLiners = Category.Create(
        name:        "Bivys & Liners", 
        slug:        "bivys-liners",
        imageUrl:    "products/hyperlite-mountain-gear-bug-bivy.webp");
        
    [SeededEntity]
    public static readonly Category FireStarters = Category.Create(
        name:        "Fire Starters", 
        slug:        "fire-starters",
        imageUrl:    "products/vargo-ultimate-fire-starter-blaze.webp");
        
    [SeededEntity]
    public static readonly Category Cutlery = Category.Create(
        name:        "Cutlery", 
        slug:        "cutlery",
        imageUrl:    "products/vargo-spork-ulv.webp");
        
    [SeededEntity]
    public static readonly Category StuffSacks = Category.Create(
        name:        "Stuff Sacks", 
        slug:        "stuff-sacks",
        imageUrl:    "products/hyperlite-mountain-gear-pods.webp");
        
    [SeededEntity]
    public static readonly Category TrekkingPoles = Category.Create(
        name:        "Trekking Poles", 
        slug:        "trekking-poles",
        imageUrl:    "products/durston-incline-trekking-poles.webp");
        
    [SeededEntity]
    public static readonly Category Stoves = Category.Create(
        name:        "Stoves", 
        slug:        "stoves",
        imageUrl:    "products/msr-pocket-rocket-2-stove.webp");
        
    [SeededEntity]
    public static readonly Category CareProtection = Category.Create(
        name:        "Care & Protection", 
        slug:        "care-protection",
        imageUrl:    "products/zpacks-arc-backpack-belt.webp");
        
    [SeededEntity]
    public static readonly Category PotsPans = Category.Create(
        name:        "Pots & Pans", 
        slug:        "pots-pans",
        imageUrl:    "products/vargo-titanium-bot--700.webp");
        
    [SeededEntity]
    public static readonly Category Accessories = Category.Create(
        name:        "Accessories", 
        slug:        "accessories",
        imageUrl:    "products/thermarest-z-seat-sol.webp");
}