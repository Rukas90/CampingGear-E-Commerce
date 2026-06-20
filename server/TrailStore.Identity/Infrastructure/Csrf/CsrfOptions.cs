using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Api.Infrastructure.Csrf;

[AppOptions("CSRF")]
public class CsrfOptions
{
    public required string SecretKey { get; init; }
}