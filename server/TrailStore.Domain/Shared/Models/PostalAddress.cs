using System.Diagnostics.CodeAnalysis;

namespace TrailStore.Domain.Shared.Models;

public record PostalAddress
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

public record ShippingAddress : PostalAddress
{
    [SetsRequiredMembers]
    public ShippingAddress(PostalAddress source) : base(source) { }
}

public record BillingAddress : PostalAddress
{
    [SetsRequiredMembers]
    public BillingAddress(PostalAddress source) : base(source) { }
}