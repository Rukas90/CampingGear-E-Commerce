using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Domain.RefreshTokens;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Infrastructure.Refresh;

[AppService<IRefreshService>]
public class RefreshService(
    IOptions<RefreshOptions> options, 
    IRefreshRepository repository, IPasswordHasher passwordHasher) : IRefreshService
{
    private readonly RefreshOptions refreshOptions = options.Value;

    public RefreshFamily CreateNewFamily(User user)
    {
        var newFamily = RefreshFamily.Create(user.Id);
        
        repository.Add(newFamily);
        
        return newFamily;
    }

    public async Task<Result<RefreshFamily>> ValidateToken(string token, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(token))
        {
            return RefreshProblems.TokenInvalid;
        }
        
        var lookupHash = GenerateLookupHash(token);
        var family = await repository.FindByLookupHashAsync(lookupHash, ct);

        if (family is null)
        {
            return RefreshProblems.TokenInvalid;
        }

        var findResult = family.FindTokenHash(lookupHash);

        if (!findResult.IsSuccess)
        {
            return findResult.Problem;
        }

        var tokenHash = findResult.Value;
        var isValid = passwordHasher.Verify(token, tokenHash);

        if (!isValid)
        {
            return RefreshProblems.TokenInvalid;
        }

        return Result.Success(family);
    }

    public void RevokeToken(RefreshFamily family, string token)
    {
        var lookupHash = GenerateLookupHash(token);

        family.RevokeToken(lookupHash);
    }

    public string CreateNewToken(RefreshFamily family)
    {
        var token = CreateTokenValue();
        var tokenHash = passwordHasher.Hash(token);
        
        family.IssueToken(
            tokenHash, GenerateLookupHash(token), TimeSpan.FromMinutes(refreshOptions.ExpireMinutes));
        
        return token;
    }

    public async Task<Result> RevokeTokenFamily(string token, CancellationToken ct)
    {
        var lookupHash = GenerateLookupHash(token);
        var family = await repository.FindByLookupHashAsync(lookupHash, ct);

        if (family is null)
        {
            return RefreshProblems.TokenNotFound;
        }
        
        family.Revoke();

        return Result.Ok();
    }

    private string GenerateLookupHash(string token)
    {
        var keyBytes = Encoding.UTF8.GetBytes(refreshOptions.LookupSecretKey);
        var tokenBytes = Encoding.UTF8.GetBytes(token);

        return Convert.ToHexString(HMACSHA256.HashData(keyBytes, tokenBytes));
    }
    
    private static string CreateTokenValue()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }
}