using TrailStore.Ordering.Domain.Countries.Models;

namespace TrailStore.Ordering.Api.Endpoints.GetCountries;

public static class CountryMapping
{
    public static IEnumerable<CountryResponse> ToResponses(this IEnumerable<Country> countries)
        => countries.Select(ToResponse);
    
    public static CountryResponse ToResponse(this Country country)
        => new()
        {
            Code = country.Code,
            Name = country.Name,
            PostalCodeLabel = country.PostalCodeLabel,
            RegionLabel = country.RegionLabel,
            PostalCode = country.PostalCode,
            HasRegion = country.HasRegion,
            PhoneCode =  country.PhoneCode
        };
}