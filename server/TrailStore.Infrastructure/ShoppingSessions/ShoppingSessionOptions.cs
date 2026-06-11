using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.ShoppingSessions;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

[AppOptions("ShoppingSession")]
public class ShoppingSessionOptions
{
    public int ExpiryMinutes { get; init; } = 43_200;
    
    public TimeSpan ExpiryTime => TimeSpan.FromMinutes(ExpiryMinutes);
}