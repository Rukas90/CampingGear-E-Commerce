using System.Diagnostics.CodeAnalysis;

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

    public PostalAddress() { }

    [SetsRequiredMembers]
    protected PostalAddress(PostalAddress source)
    {
        CountryCode = source.CountryCode;
        RecipientFirstName = source.RecipientFirstName;
        RecipientLastName = source.RecipientLastName;
        Company = source.Company;
        AddressLine = source.AddressLine;
        ApartmentSuite = source.ApartmentSuite;
        City = source.City;
        Region = source.Region;
        PostalCode = source.PostalCode;
        PhoneNumber = source.PhoneNumber;
    }
    
    public static PostalAddress Empty => new()
    {
        CountryCode = "",
        RecipientFirstName = "",
        RecipientLastName = "",
        AddressLine = "",
        City = "",
        PostalCode = "",
        PhoneNumber = ""
    };
}