using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data;

public class Categories
{
    [SeededEntity]
    public static readonly Category HandheldGps = Category.Create(
        name:        "Handheld GPS", 
        slug:        "handheld-gps", 
        imageUrl:    "img/products/gpsmap-67-xl");
        
    [SeededEntity]
    public static readonly Category SleepingBags = Category.Create(
        name:        "Sleeping Bags", 
        slug:        "sleeping-bags", 
        imageUrl:    "img/products/western-mountaineering-alpinlite-20");
        
    [SeededEntity]
    public static readonly Category SleepingMats = Category.Create(
        name:        "Sleeping Mats", 
        slug:        "sleeping-mats", 
        imageUrl:    "img/products/thermarest-neoair-xlite");
        
    [SeededEntity]
    public static readonly Category Quilts = Category.Create(
        name:        "Quilts", 
        slug:        "quilts", 
        imageUrl:    "img/products/zpacks-summer-quilt--winter-liner");
        
    [SeededEntity]
    public static readonly Category Tents = Category.Create(
        name:        "Tents", 
        slug:        "tents", 
        imageUrl:    "img/products/durston-x-mid-pro-1---3");
        
    [SeededEntity]
    public static readonly Category Backpacks = Category.Create(
        name:        "Backpacks", 
        slug:        "backpacks", 
        imageUrl:    "img/products/gregory-baltoro-75-man");
        
    [SeededEntity]
    public static readonly Category Sunglasses = Category.Create(
        name:        "Sunglasses", 
        slug:        "sunglasses", 
        imageUrl:    "img/products/ombraz-refugio-armless");
        
    [SeededEntity]
    public static readonly Category HydrationFiltration = Category.Create(
        name:        "Hydration/Filtration", 
        slug:        "hydration-filtration",
        imageUrl:    "img/products/gossamer-gear-bottle-rocket");
        
    [SeededEntity]
    public static readonly Category BivysLiners = Category.Create(
        name:        "Bivys & Liners", 
        slug:        "bivys-liners",
        imageUrl:    "img/products/hyperlite-mountain-gear-bug-bivy");
        
    [SeededEntity]
    public static readonly Category FireStarters = Category.Create(
        name:        "Fire Starters", 
        slug:        "fire-starters",
        imageUrl:    "img/products/vargo-ultimate-fire-starter-blaze");
        
    [SeededEntity]
    public static readonly Category Cutlery = Category.Create(
        name:        "Cutlery", 
        slug:        "cutlery",
        imageUrl:    "img/products/vargo-spork-ulv");
        
    [SeededEntity]
    public static readonly Category StuffSacks = Category.Create(
        name:        "Stuff Sacks", 
        slug:        "stuff-sacks",
        imageUrl:    "img/products/hyperlite-mountain-gear-pods");
        
    [SeededEntity]
    public static readonly Category TrekkingPoles = Category.Create(
        name:        "Trekking Poles", 
        slug:        "trekking-poles",
        imageUrl:    "img/products/durston-incline-trekking-poles");
        
    [SeededEntity]
    public static readonly Category Stoves = Category.Create(
        name:        "Stoves", 
        slug:        "stoves",
        imageUrl:    "img/products/msr-pocket-rocket-2-stove");
        
    [SeededEntity]
    public static readonly Category CareProtection = Category.Create(
        name:        "Care & Protection", 
        slug:        "care-protection",
        imageUrl:    "img/products/zpacks-arc-backpack-belt");
        
    [SeededEntity]
    public static readonly Category PotsPans = Category.Create(
        name:        "Pots & Pans", 
        slug:        "pots-pans",
        imageUrl:    "img/products/vargo-titanium-bot--700");
        
    [SeededEntity]
    public static readonly Category Accessories = Category.Create(
        name:        "Accessories", 
        slug:        "accessories",
        imageUrl:    "img/products/thermarest-z-seat-sol");
}