using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Orders;

[AppOptions("Order")]
public class OrderSettings
{
    public required string TokenSecretKey { get; init; }
}