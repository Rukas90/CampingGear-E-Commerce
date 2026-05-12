using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Auth.Csrf;

[AppOptions("CSRF")]
public class CsrfOptions
{
    public required string SecretKey { get; init; }
}