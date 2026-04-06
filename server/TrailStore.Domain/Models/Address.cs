using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public enum CountryCode
{
    US,
    DE,
    LT
}
public class Address : IModel<Address>
{
    public required Id<Address> Id              { get; init; }
    public required CountryCode CountryCode     { get; init; }
    public required string      RecipientName   { get; init; } = string.Empty;
    public string?              Company         { get; init; }
    public required string      AddressLine1    { get; init; } = string.Empty;
    public string?              AddressLine2    { get; init; }
    public string?              AddressLine3    { get; init; }
    public required string      City            { get; init; } = string.Empty;
    public string?              Region          { get; init; }
    public required string      PostalCode      { get; init; } = string.Empty;
    public required string      PhoneNumber     { get; init; } = string.Empty;
    public required bool        IsDefault       { get; init; }
    public required Id<Customer>    UserId          { get; init; }
    
    public Customer Customer { get; init; } = null!;
};