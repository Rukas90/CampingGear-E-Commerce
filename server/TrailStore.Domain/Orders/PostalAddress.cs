namespace TrailStore.Domain.Orders;

public class PostalAddress
{
    public required string CountryCode   { get; init; }
    public required string RecipientName { get; init; }
    public string?         Company       { get; init; }
    public required string AddressLine1  { get; init; }
    public string?         AddressLine2  { get; init; }
    public required string City          { get; init; }
    public string?         Region        { get; init; }
    public required string PostalCode    { get; init; }
    public required string PhoneNumber   { get; init; }
}