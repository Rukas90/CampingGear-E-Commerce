using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Auth.Jwt;

[AppOptions(key: "Jwt")]
public class JwtOptions
{
    public required string Issuer                   { get; init; }
    public required string Audience                 { get; init; }
    public required string SecretKey                { get; init; }
    public int             AccessTokenExpiryMinutes { get; init; } = 15;
}