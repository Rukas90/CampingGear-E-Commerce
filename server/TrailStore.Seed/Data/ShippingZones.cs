using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data;

// ReSharper disable UnusedType.Global

public static class ShippingZones
{
    [SeededEntity]
    public static readonly ShippingZone Domestic = ShippingZone.Create(
        "Domestic", "LT");
 
    [SeededEntity]
    public static readonly ShippingZone EuCore = ShippingZone.Create(
        "EU Core", "DE", "FR", "IT", "ES", "NL", "BE", "AT", "PL", "CZ", "SK", "HU", "RO", "HR", "SI", "EE", "LV", "GR", "PT", "DK", "SE", "FI");
 
    [SeededEntity]
    public static readonly ShippingZone EuPeripheral = ShippingZone.Create(
        "EU Peripheral", "BG", "MT", "CY", "IE", "LU", "IS", "AD", "MC", "LI");
 
    [SeededEntity]
    public static readonly ShippingZone UkAndNonEuEurope = ShippingZone.Create(
        "UK & Non-EU Europe", "GB", "CH", "NO");
 
    [SeededEntity]
    public static readonly ShippingZone EasternEuropeNonEu = ShippingZone.Create(
        "Eastern Europe (Non-EU)", "UA", "RS", "BY", "BA", "ME", "MK", "AL", "MD");
 
    [SeededEntity]
    public static readonly ShippingZone NorthAmerica = ShippingZone.Create(
        "North America", "US", "CA", "MX", "GT", "CR", "PA", "DO", "JM", "TT", "CU");
 
    [SeededEntity]
    public static readonly ShippingZone AustraliaAndNz = ShippingZone.Create(
        "Australia & New Zealand", "AU", "NZ", "FJ", "PG");
 
    [SeededEntity]
    public static readonly ShippingZone EastAndSoutheastAsia = ShippingZone.Create(
        "East & Southeast Asia", "JP", "KR", "SG", "HK", "TW", "CN", "TH", "MY", "VN", "ID", "PH", "MN", "KH", "MM", "MO");
 
    [SeededEntity]
    public static readonly ShippingZone SouthAsia = ShippingZone.Create(
        "South Asia", "IN", "PK", "BD", "LK", "NP");
 
    [SeededEntity]
    public static readonly ShippingZone MiddleEast = ShippingZone.Create(
        "Middle East", "AE", "SA", "QA", "KW", "BH", "OM");
 
    [SeededEntity]
    public static readonly ShippingZone Levant = ShippingZone.Create(
        "Levant & Turkey", "IL", "JO", "LB", "IQ", "TR", "IR");
 
    [SeededEntity]
    public static readonly ShippingZone SouthAmerica = ShippingZone.Create(
        "South America", "BR", "AR", "CL", "CO", "PE", "VE", "EC", "BO", "PY", "UY");
 
    [SeededEntity]
    public static readonly ShippingZone Africa = ShippingZone.Create(
        "Africa", "ZA", "NG", "EG", "KE", "GH", "ET", "TZ", "UG", "MA", "DZ", "TN", "SN", "CI", "CM", "AO", "MZ", "ZM", "ZW");
    
    [SeededEntity]
    public static readonly ShippingZone Worldwide = ShippingZone.Create(
        "Worldwide");
}