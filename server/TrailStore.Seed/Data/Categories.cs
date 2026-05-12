using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data;

// ReSharper disable All
public static class Categories
{
    [SeededEntity] public static readonly Category HandheldGps = Category.Create(
        groupId: CategoryGroups.NavigationSafety.Id,
        name: "Handheld GPS",
        slug: "handheld-gps",
        imageUrl: "products/gpsmap-67-xl.webp");

    [SeededEntity] public static readonly Category SleepingBags = Category.Create(
        groupId: CategoryGroups.SleepSystem.Id,
        name: "Sleeping Bags",
        slug: "sleeping-bags",
        imageUrl: "products/western-mountaineering-alpinlite-20.webp");

    [SeededEntity] public static readonly Category SleepingMats = Category.Create(
        groupId: CategoryGroups.SleepSystem.Id,
        name: "Sleeping Mats",
        slug: "sleeping-mats",
        imageUrl: "products/thermarest-neoair-xlite.webp");

    [SeededEntity] public static readonly Category Quilts = Category.Create(
        groupId: CategoryGroups.SleepSystem.Id,
        name: "Quilts",
        slug: "quilts",
        imageUrl: "products/zpacks-summer-quilt--winter-liner-blu.webp");

    [SeededEntity] public static readonly Category Tents = Category.Create(
        groupId: CategoryGroups.SleepSystem.Id,
        name: "Tents",
        slug: "tents",
        imageUrl: "products/durston-x-mid-pro-1---3.webp");

    [SeededEntity] public static readonly Category Backpacks = Category.Create(
        groupId: CategoryGroups.HikingCamping.Id,
        name: "Backpacks",
        slug: "backpacks",
        imageUrl: "products/gregory-baltoro-75-man.webp");

    [SeededEntity] public static readonly Category BivysLiners = Category.Create(
        groupId: CategoryGroups.SleepSystem.Id,
        name: "Bivys & Liners",
        slug: "bivys-liners",
        imageUrl: "products/hyperlite-mountain-gear-bug-bivy.webp");

    [SeededEntity] public static readonly Category StuffSacks = Category.Create(
        groupId: CategoryGroups.HikingCamping.Id,
        name: "Stuff Sacks",
        slug: "stuff-sacks",
        imageUrl: "products/hyperlite-mountain-gear-pods.webp");

    [SeededEntity] public static readonly Category TrekkingPoles = Category.Create(
        groupId: CategoryGroups.HikingCamping.Id,
        name: "Trekking Poles",
        slug: "trekking-poles",
        imageUrl: "products/durston-incline-trekking-poles.webp");

    [SeededEntity] public static readonly Category CareProtection = Category.Create(
        groupId: CategoryGroups.ApparelProtection.Id,
        name: "Care & Protection",
        slug: "care-protection",
        imageUrl: "products/zpacks-arc-backpack-belt.webp");

    [SeededEntity] public static readonly Category Accessories = Category.Create(
        groupId: CategoryGroups.HikingCamping.Id,
        name: "Accessories",
        slug: "accessories",
        imageUrl: "products/thermarest-z-seat-sol.webp");
}