using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Infrastructure.Sessions;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

[AppOptions("ShoppingSession")]
public class ShoppingSessionOptions
{
    public int ExpiryMinutes { get; init; } = 43_200;
    
    public TimeSpan ExpiryTime => TimeSpan.FromMinutes(ExpiryMinutes);
}