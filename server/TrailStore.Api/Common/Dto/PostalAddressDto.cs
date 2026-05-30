namespace TrailStore.Api.Common.Dto;

public class PostalAddressDto
{
    public string? CountryCode { get; init; }
    public string? RecipientFirstName { get; init; }
    public string? RecipientLastName { get; init; }
    public string? Company { get; init; }
    public string? AddressLine { get; init; }
    public string? ApartmentSuite { get; init; }
    public string? City { get; init; }
    public string? Region { get; init; }
    public string? PostalCode { get; init; }
    public string? PhoneNumber { get; init; }
}