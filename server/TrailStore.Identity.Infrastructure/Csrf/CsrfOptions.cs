using TrailStore.Shared.DependencyInjection;

namespace TrailStore.Identity.Infrastructure.Csrf;

[AppOptions("CSRF")]
public class CsrfOptions
{
    public required string SecretKey { get; init; }
}