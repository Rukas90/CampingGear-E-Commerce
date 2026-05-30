using TrailStore.Api.Countries.Dto;
using TrailStore.Domain.Countries.Models;

namespace TrailStore.Api.Countries.Mapping;

public static class CountryMapping
{
    public static IEnumerable<CountryDto> ToDto(this IEnumerable<Country> countries)
        => countries.Select(ToDto);
    
    public static CountryDto ToDto(this Country country)
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