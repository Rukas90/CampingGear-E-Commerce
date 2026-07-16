namespace TrailStore.Ordering.Api.Checkouts;

public class CheckoutContactResponse
{
    public string? EmailAddress { get; init; }
    public bool IsEmailReadOnly { get; init; }
}