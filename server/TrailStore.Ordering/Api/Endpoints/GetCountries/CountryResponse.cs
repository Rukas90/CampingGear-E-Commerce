using TrailStore.Ordering.Domain.Countries.Enums;

namespace TrailStore.Ordering.Api.Endpoints.GetCountries;

public class CountryResponse
{
    public required string Code { get; init; }
    public required string Name { get; init; }

    public string? PostalCodeLabel { get; init; }
    public string? RegionLabel { get; init; }

    public PostalCodeRequirement PostalCode { get; init; }
    public bool HasRegion { get; init; }

    public required string PhoneCode { get; init; }
}