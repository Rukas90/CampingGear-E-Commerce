using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data;

// ReSharper disable UnusedType.Global

public static class ShippingMethods
{
    // Domestic
    [SeededEntity]
    public static readonly ShippingMethod DomesticStandard = ShippingMethod.Create(
        ShippingZones.Domestic.Id,
        "standard",
        "Standard Shipping",
        "Typically 3-5 Business Days. All Taxes and Fees Included.",
        3.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod DomesticExpress = ShippingMethod.Create(
        ShippingZones.Domestic.Id,
        "express",
        "Express Shipping",
        "Typically 1-2 Business Days. All Taxes and Fees Included.",
        6.99m);
 
    // EU Core
    [SeededEntity]
    public static readonly ShippingMethod EuCoreStandard = ShippingMethod.Create(
        ShippingZones.EuCore.Id,
        "standard",
        "Standard Shipping",
        "Typically 5-7 Business Days. All Taxes and Fees Included.",
        7.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod EuCoreExpress = ShippingMethod.Create(
        ShippingZones.EuCore.Id,
        "express",
        "DHL Express",
        "Typically 2-3 Business Days. All Taxes and Fees Included.",
        14.99m);
 
    // EU Peripheral
    [SeededEntity]
    public static readonly ShippingMethod EuPeripheralStandard = ShippingMethod.Create(
        ShippingZones.EuPeripheral.Id,
        "standard",
        "Standard Shipping",
        "Typically 7-10 Business Days. All Taxes and Fees Included.",
        9.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod EuPeripheralExpress = ShippingMethod.Create(
        ShippingZones.EuPeripheral.Id,
        "express",
        "DHL Express",
        "Typically 3-5 Business Days. All Taxes and Fees Included.",
        17.99m);
 
    // UK & Non-EU Europe
    [SeededEntity]
    public static readonly ShippingMethod UkStandard = ShippingMethod.Create(
        ShippingZones.UkAndNonEuEurope.Id,
        "standard",
        "Standard Shipping",
        "Typically 7-10 Business Days. (Includes Taxes & Duties)",
        12.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod UkExpress = ShippingMethod.Create(
        ShippingZones.UkAndNonEuEurope.Id,
        "express",
        "FedEx Express",
        "Typically 3-5 Business Days. (Includes Taxes & Duties)",
        24.99m);
 
    // Eastern Europe Non-EU
    [SeededEntity]
    public static readonly ShippingMethod EasternEuropeStandard = ShippingMethod.Create(
        ShippingZones.EasternEuropeNonEu.Id,
        "standard",
        "Standard Shipping",
        "Typically 10-14 Business Days. All Taxes and Fees Included.",
        14.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod EasternEuropeExpress = ShippingMethod.Create(
        ShippingZones.EasternEuropeNonEu.Id,
        "express",
        "DHL Express",
        "Typically 5-7 Business Days. All Taxes and Fees Included.",
        27.99m);
 
    // North America
    [SeededEntity]
    public static readonly ShippingMethod NorthAmericaStandard = ShippingMethod.Create(
        ShippingZones.NorthAmerica.Id,
        "standard",
        "Standard Shipping",
        "Typically 7-14 Business Days. (Includes Taxes & Duties)",
        14.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod NorthAmericaExpress = ShippingMethod.Create(
        ShippingZones.NorthAmerica.Id,
        "express",
        "FedEx Express",
        "Typically 3-5 Business Days. (Includes Taxes & Duties)",
        34.99m);
 
    // Australia & NZ
    [SeededEntity]
    public static readonly ShippingMethod AustraliaStandard = ShippingMethod.Create(
        ShippingZones.AustraliaAndNz.Id,
        "standard",
        "Standard Shipping",
        "Typically 10-14 Business Days. (Includes Taxes & Duties)",
        16.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod AustraliaExpress = ShippingMethod.Create(
        ShippingZones.AustraliaAndNz.Id,
        "express",
        "FedEx Express",
        "Typically 5-7 Business Days. (Includes Taxes & Duties)",
        34.99m);
 
    // East & Southeast Asia
    [SeededEntity]
    public static readonly ShippingMethod EastAsiaStandard = ShippingMethod.Create(
        ShippingZones.EastAndSoutheastAsia.Id,
        "standard",
        "Standard Shipping",
        "Typically 10-14 Business Days. (Includes Taxes & Duties)",
        14.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod EastAsiaExpress = ShippingMethod.Create(
        ShippingZones.EastAndSoutheastAsia.Id,
        "express",
        "DHL Express",
        "Typically 4-6 Business Days. (Includes Taxes & Duties)",
        29.99m);
 
    // South Asia
    [SeededEntity]
    public static readonly ShippingMethod SouthAsiaStandard = ShippingMethod.Create(
        ShippingZones.SouthAsia.Id,
        "standard",
        "Standard Shipping",
        "Typically 12-18 Business Days. (Includes Taxes & Duties)",
        16.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod SouthAsiaExpress = ShippingMethod.Create(
        ShippingZones.SouthAsia.Id,
        "express",
        "DHL Express",
        "Typically Typically 5-7 Business Days. (Includes Taxes & Duties)",
        32.99m);
 
    // Middle East
    [SeededEntity]
    public static readonly ShippingMethod MiddleEastStandard = ShippingMethod.Create(
        ShippingZones.MiddleEast.Id,
        "standard",
        "Standard Shipping",
        "Typically 10-14 Business Days. (Includes Taxes & Duties)",
        14.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod MiddleEastExpress = ShippingMethod.Create(
        ShippingZones.MiddleEast.Id,
        "express",
        "FedEx Express",
        "Typically 4-6 Business Days. (Includes Taxes & Duties)",
        29.99m);
 
    // Levant & Turkey
    [SeededEntity]
    public static readonly ShippingMethod LevantStandard = ShippingMethod.Create(
        ShippingZones.Levant.Id,
        "standard",
        "Standard Shipping",
        "Typically 12-16 Business Days. (Includes Taxes & Duties)",
        16.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod LevantExpress = ShippingMethod.Create(
        ShippingZones.Levant.Id,
        "express",
        "DHL Express",
        "Typically 5-7 Business Days. (Includes Taxes & Duties)",
        31.99m);
 
    // South America
    [SeededEntity]
    public static readonly ShippingMethod SouthAmericaStandard = ShippingMethod.Create(
        ShippingZones.SouthAmerica.Id,
        "standard",
        "Standard Shipping",
        "Typically 14-21 Business Days. (Includes Taxes & Duties)",
        17.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod SouthAmericaExpress = ShippingMethod.Create(
        ShippingZones.SouthAmerica.Id,
        "express",
        "FedEx Express",
        "Typically 6-8 Business Days. (Includes Taxes & Duties)",
        36.99m);
 
    // Africa
    [SeededEntity]
    public static readonly ShippingMethod AfricaStandard = ShippingMethod.Create(
        ShippingZones.Africa.Id,
        "standard",
        "Standard Shipping",
        "Typically 14-21 Business Days. (Includes Taxes & Duties)",
        19.99m);
 
    [SeededEntity]
    public static readonly ShippingMethod AfricaExpress = ShippingMethod.Create(
        ShippingZones.Africa.Id,
        "express",
        "DHL Express",
        "Typically 7-10 Business Days. (Includes Taxes & Duties)",
        39.99m);
    
    [SeededEntity]
    public static readonly ShippingMethod WorldwideStandard = ShippingMethod.Create(
        ShippingZones.Worldwide.Id,
        "standard",
        "Standard Shipping",
        "14-28 Business Days. (Includes Taxes & Duties)",
        24.99m);

    [SeededEntity]
    public static readonly ShippingMethod WorldwideExpress = ShippingMethod.Create(
        ShippingZones.Worldwide.Id,
        "express",
        "Express Worldwide",
        "7-10 Business Days. (Includes Taxes & Duties)",
        44.99m);
}
