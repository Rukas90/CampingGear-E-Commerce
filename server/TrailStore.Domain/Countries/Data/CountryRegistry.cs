using System.Text.Json;
using TrailStore.Domain.Countries.Models;

namespace TrailStore.Domain.Countries.Data;

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
        var basePath = Path.GetDirectoryName(DomainAssembly.Reference.Location)!;

        var json = File.ReadAllText(
            Path.Combine(basePath, "Countries/Data", "Countries.json"));
        
        var list = JsonSerializer.Deserialize<List<Country>>(json, JsonSerializerOptions) ?? [];
        Countries = new Dictionary<string, Country>(StringComparer.OrdinalIgnoreCase);

        foreach (var country in list)
        {
            Countries[country.Code] = country;
        }
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