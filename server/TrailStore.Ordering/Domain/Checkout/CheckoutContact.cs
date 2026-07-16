namespace TrailStore.Ordering.Domain.Checkout;

public class CheckoutContact
{
    public string? EmailAddress { get; init; }
    public required bool IsEmailReadOnly { get; init; }
}