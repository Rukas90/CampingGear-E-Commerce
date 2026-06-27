using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Infrastructure.Checkout;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

[AppOptions("CheckoutSession")]
public class CheckoutSessionOptions
{
    public int ExpiryMinutesForCustomers { get; init; } = 43_200;
    public int ExpiryMinutesForGuests { get; init; } = 1440;
    
    public TimeSpan ExpiresForCustomer => TimeSpan.FromMinutes(ExpiryMinutesForCustomers);
    
    public TimeSpan ExpiresForGuest => TimeSpan.FromMinutes(ExpiryMinutesForGuests);
}