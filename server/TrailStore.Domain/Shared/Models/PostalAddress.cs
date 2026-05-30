namespace TrailStore.Domain.Shared.Models;

public class PostalAddress
{
    public required string CountryCode { get; init; }
    public required string RecipientFirstName { get; init; }
    public required string RecipientLastName { get; init; }
    public string? Company { get; init; }
    public required string AddressLine { get; init; }
    public string? ApartmentSuite { get; init; }
    public required string City { get; init; }
    public string? Region { get; init; }
    public required string PostalCode { get; init; }
    public required string PhoneNumber { get; init; }
}