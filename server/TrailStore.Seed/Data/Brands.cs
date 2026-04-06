using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data;

public class Brands
{
    [SeededEntity]
    public static readonly Brand Garmin = Brand.Create(
        name:        "Garmin", 
        slug:        "garmin",
        logoUrl:     "img/brands/garmin",
        websiteUrl:  "https://www.garmin.com/",
        description: "Leading technology company known for GPS devices, smartwatches, and outdoor navigation tools");
    
    [SeededEntity]
    public static readonly Brand Gregory = Brand.Create(
        name:        "Gregory", 
        slug:        "gregory",
        logoUrl:     "img/brands/gregory",
        websiteUrl:  "https://www.gregory.com/",
        description: "Premier U.S.-based brand specializing in high-performance, comfortable backpacks and travel gear");
        
    [SeededEntity]
    public static readonly Brand Durston = Brand.Create(
        name:        "Durston", 
        slug:        "durston",
        logoUrl:     "img/brands/durston",
        websiteUrl:  "https://durstongear.com/",
        description: "Premium Canadian ultralight backpacking gear");
        
    [SeededEntity]
    public static readonly Brand Zpacks = Brand.Create(
        name:        "Zpacks", 
        slug:        "zpacks", 
        logoUrl:     "img/brands/zpacks",
        websiteUrl:  "https://zpacks.com/",
        description: "Premier U.S. based ultralight backpacking gear");
    
    [SeededEntity]
    public static readonly Brand Gossamer = Brand.Create(
        name:        "Gossamer Gear", 
        slug:        "gossamer-gear",
        logoUrl:     "img/brands/gossamer-gear",
        websiteUrl:  "https://www.gossamergear.com/",
        description: "Functional ultralight backpacking and hiking gear");
        
    [SeededEntity]
    public static readonly Brand PalantePacks = Brand.Create(
        name:        "Palante Packs",
        slug:        "palante-packs",
        logoUrl:     "img/brands/palante-packs",
        websiteUrl:  "https://palantepacks.com/",
        description: "Ultralight packs built for fast, efficient movement");
        
    [SeededEntity]
    public static readonly Brand HyperliteMountain = Brand.Create(
        name:        "Hyperlite Mountain Gear", 
        slug:        "hyperlite-mountain", 
        logoUrl:     "img/brands/hyperlite-mountain",
        websiteUrl:  "https://hyperlitemountaingear.com/",
        description: "Ultralight, minimalist outdoor gear");
        
    [SeededEntity]
    public static readonly Brand NEMO = Brand.Create(
        name:        "NEMO Equipment", 
        slug:        "nemo-equipment", 
        logoUrl:     "img/brands/nemo",
        websiteUrl:  "https://www.nemoequipment.com/",
        description: "An award-winning American outdoor gear");
        
    [SeededEntity]
    public static readonly Brand GooseFeet = Brand.Create(
        name:        "GooseFeet Gear",
        slug:        "goosefeet-gear",
        logoUrl:     "img/brands/goosefeet-gear",
        websiteUrl:  "https://goosefeetgear.com/",
        description: "Handmade, USA-made ultralight down socks, pants, and gear");
        
    [SeededEntity]
    public static readonly Brand Alpenglow = Brand.Create(
        name:        "Alpenglow Gear",
        slug:        "alpenglow-gear",
        logoUrl:     "img/brands/alpenglow-gear",
        websiteUrl:  "https://alpenglowgear.co/",
        description: "An ultralight backpacking brand");
        
    [SeededEntity]
    public static readonly Brand Cumulus = Brand.Create(
        name:        "Cumulus",
        slug:        "cumulus",
        logoUrl:     "img/brands/cumulus",
        websiteUrl:  "https://cumulus.equipment/",
        description: "Polish high-quality, lightweight outdoor gear");
        
    [SeededEntity]
    public static readonly Brand Thermarest = Brand.Create(
        name:        "Thermarest",
        slug:        "thermarest",
        logoUrl:     "img/brands/thermarest",
        websiteUrl:  "https://thermarestcamp.com/",
        description: "Premier outdoor brand known for pioneering the self-inflating mattress");
        
    [SeededEntity]
    public static readonly Brand Tarptent = Brand.Create(
        name:        "Tarptent",
        slug:        "tarptent",
        logoUrl:     "img/brands/tarptent",
        websiteUrl:  "https://www.tarptent.com/",
        description: "Leading brand of ultralight, durable, and often single-wall shelters");
        
    [SeededEntity]
    public static readonly Brand Enlightened = Brand.Create(
        name:        "Enlightened Equipment",
        slug:        "enlightened-equipment",
        logoUrl:     "img/brands/enlightened",
        websiteUrl:  "https://enlightenedequipment.com/",
        description: "Premier high-quality, ultralight backpacking quilts, sleeping bags, and insulated clothing");
        
    [SeededEntity]
    public static readonly Brand Deuter = Brand.Create(
        name:        "Deuter",
        slug:        "deuter",
        logoUrl:     "img/brands/deuter",
        websiteUrl:  "https://www.deuter.com/",
        description: "Leading manufacturers of backpacks with high-quality standards, from trekking backpacks to daypacks");
        
    [SeededEntity]
    public static readonly Brand Warbonnet = Brand.Create(
        name:        "Warbonnet Outdoors",
        slug:        "warbonnet-outdoors",
        logoUrl:     "img/brands/warbonnet",
        websiteUrl:  "https://www.warbonnetoutdoors.com/",
        description: "Specialized American manufacturer producing high-quality, lightweight hammock gear");
        
    [SeededEntity]
    public static readonly Brand Ombraz = Brand.Create(
        name:        "Ombraz Armless",
        slug:        "ombraz-armless",
        logoUrl:     "img/brands/ombraz-armless",
        websiteUrl:  "https://ombraz.com/",
        description: "Impressively durable, secure, lightweight & comfortable. Polarized Zeiss optics");
        
    [SeededEntity]
    public static readonly Brand Vargo = Brand.Create(
        name:        "Vargo",
        slug:        "vargo",
        logoUrl:     "img/brands/vargo",
        websiteUrl:  "https://vargooutdoors.com/",
        description: "Specialized brand known for durable, lightweight, titanium backpacking gear");
        
    [SeededEntity]
    public static readonly Brand MSR = Brand.Create(
        name:        "MSR",
        slug:        "msr",
        logoUrl:     "img/brands/msr",
        websiteUrl:  "https://www.msrgear.com/",
        description: "Trusted American outdoor brand known for stoves, water filters, and tents");
        
    [SeededEntity]
    public static readonly Brand WesternMountaineering = Brand.Create(
        name:        "Western Mountaineering",
        slug:        "western-mountaineering",
        logoUrl:     "img/brands/western-mountaineering",
        websiteUrl:  "https://www.westernmountaineering.com/",
        description: "Premier American manufacturer of high-end ultralight sleeping bags, down apparel, and accessories");
}