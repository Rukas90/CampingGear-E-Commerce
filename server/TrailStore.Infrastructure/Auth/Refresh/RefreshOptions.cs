using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Auth.Refresh;

[AppOptions(key: "Refresh")]
public class RefreshOptions
{
    public required string LookupSecretKey { get; init; }
}