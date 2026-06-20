using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Api.Infrastructure.Refresh;

[AppOptions("Refresh")]
public class RefreshOptions
{
    public required string LookupSecretKey { get; init; }
    public required int ExpireMinutes { get; init; }
}