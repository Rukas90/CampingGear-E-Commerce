using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using TrailStore.Domain.Auth.Errors;
using TrailStore.Domain.Auth.Interfaces;
using TrailStore.Domain.Auth.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Shared;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Auth.Refresh;

[AppService<IRefreshService>]
public class RefreshService(
    IOptions<RefreshOptions> options,
    IRefreshRepository refreshRepository,
    IPasswordHasher passwordHasher) : IRefreshService
{
    private readonly RefreshOptions _options = options.Value;

    public async Task<string> GenerateToken(Id<Customer> customerId, Id<RefreshTokenFamily>? familyId = null,
        CancellationToken ct = default)
    {
        var token = CreateTokenValue();
        var lookupHash = GenerateLookupHash(token);

        await refreshRepository.CreateAsync(new RefreshToken
        {
            Id = Id<RefreshToken>.New(),
            CustomerId = customerId,
            FamilyId = familyId ?? Id<RefreshTokenFamily>.New(),
            TokenHash = passwordHasher.Hash(token),
            LookupHash = lookupHash,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(30)
        }, ct);

        return token;
    }

    public async Task<Result<RefreshToken>> ValidateToken(string? token, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(token)) return AuthProblems.RefreshTokenInvalid;

        var result = await FindRefreshToken(token, ct);

        if (!result.IsSuccess) return AuthProblems.RefreshTokenInvalid;

        var refreshToken = result.Value!;

        if (refreshToken.RevokedAt is not null)
        {
            await refreshRepository.RevokeFamily(refreshToken.FamilyId, ct);

            return AuthProblems.RefreshTokenReused;
        }

        if (DateTime.UtcNow > refreshToken.ExpiresAt) return AuthProblems.RefreshTokenExpired;

        var isValid = passwordHasher.Verify(token, refreshToken.TokenHash);

        if (!isValid) return AuthProblems.RefreshTokenInvalid;

        return refreshToken;
    }

    public async Task<Result<RefreshToken>> FindRefreshToken(string token, CancellationToken ct)
    {
        var lookingHash = GenerateLookupHash(token);
        var refreshToken = await refreshRepository.GetByLookupHashAsync(lookingHash, ct);

        if (refreshToken is null) return AuthProblems.RefreshTokenNotFound;

        return refreshToken;
    }

    private string GenerateLookupHash(string token)
    {
        var keyBytes = Encoding.UTF8.GetBytes(_options.LookupSecretKey);
        var tokenBytes = Encoding.UTF8.GetBytes(token);

        return Convert.ToHexString(HMACSHA256.HashData(keyBytes, tokenBytes));
    }

    private static string CreateTokenValue()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }
}