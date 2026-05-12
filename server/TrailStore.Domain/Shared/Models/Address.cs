using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Address : IModel<Address>
{
    public required Id<Address> Id { get; init; }
    public required string CountryCode { get; init; }
    public required string RecipientName { get; init; }
    public string? Company { get; init; }
    public required string AddressLine1 { get; init; }
    public string? AddressLine2 { get; init; }
    public required string City { get; init; }
    public string? Region { get; init; }
    public required string PostalCode { get; init; }
    public required string PhoneNumber { get; init; }
    public required bool IsDefault { get; init; }
    public required Id<Customer> CustomerId { get; init; }

    public Customer Customer { get; init; } = null!;
}