using TrailStore.Domain.Countries.Enums;

namespace TrailStore.Api.Countries.Dto;

public class CountryDto
{
    public required string Code { get; init; }
    public required string Name { get; init; }

    public string? PostalCodeLabel { get; init; }
    public string? RegionLabel { get; init; }

    public PostalCodeRequirement PostalCode { get; init; }
    public bool HasRegion { get; init; }

    public required string PhoneCode { get; init; }
}