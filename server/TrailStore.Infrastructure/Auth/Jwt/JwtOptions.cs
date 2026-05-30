using TrailStore.Shared.Common;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace TrailStore.Infrastructure.Auth.Jwt;

[AppOptions("Jwt")]
public class JwtOptions
{
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required string SecretKey { get; init; }
    public int AccessTokenExpiryMinutes { get; init; } = 15;
}