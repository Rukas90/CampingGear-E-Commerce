using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Api.Infrastructure.Auth;

[AppOptions("Jwt")]
public class JwtOptions
{
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required string SecretKey { get; init; }
    public int AccessTokenExpiryMinutes { get; init; } = 15;
}