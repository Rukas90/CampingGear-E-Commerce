using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.ShoppingSessions;

[AppOptions("ShoppingSession")]
public class ShoppingSessionOptions
{
    public int ExpiryMinutes { get; init; } = 43_200;
}