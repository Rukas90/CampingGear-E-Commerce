using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Infrastructure.Carts;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

[AppOptions("Cart")]
public class CartOptions
{
    public int ExpiryMinutes { get; init; } = 43_200;
    
    public TimeSpan ExpiryTime => TimeSpan.FromMinutes(ExpiryMinutes);
}