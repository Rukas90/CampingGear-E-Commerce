using System.Text.Json;
using TrailStore.Ordering.Domain.Countries.Models;

namespace TrailStore.Ordering.Domain.Countries.Data;

public static class CountryRegistry
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    
    private static readonly Dictionary<string, Country> Countries;

    public static IEnumerable<Country> All => Countries.Values;
    public static IEnumerable<string> SupportedCountryCodes => Countries.Keys;

    static CountryRegistry()
    {
        var basePath = Path.GetDirectoryName(OrderingMarker.Reference.Location)!;

        var json = File.ReadAllText(
            Path.Combine(basePath, "Domain/Countries/Data", "Countries.json"));
        
        Countries = JsonSerializer.Deserialize<Dictionary<string, Country>>(
            json, JsonSerializerOptions) ?? [];
    }
    
    public static Country? For(string countryCode)
    {
        return Countries.GetValueOrDefault(countryCode);
    }

    public static bool IsSupported(string countryCode)
    {
        return Countries.ContainsKey(countryCode);
    }
}