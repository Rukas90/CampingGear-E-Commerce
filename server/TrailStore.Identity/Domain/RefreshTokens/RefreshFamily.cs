using TrailStore.Identity.Api.Domain.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Api.Domain.RefreshTokens;

public class RefreshFamily : AggregateRoot<RefreshFamily>
{
    public required Id<User> UserId { get; init; }

    private readonly List<RefreshToken> _refreshTokens = [];
    public IReadOnlyList<RefreshToken> RefreshTokens => _refreshTokens;
    
    public static RefreshFamily Create(Id<User> userId)
        => new()
        {
            Id = Id<RefreshFamily>.New(),
            UserId = userId
        };

    public void IssueToken(string tokenHash, string lookupHash, TimeSpan expireTime)
    {
        var token = RefreshToken.Create(Id, tokenHash, lookupHash, expireTime);
        
        _refreshTokens.Add(token);
    }
    

    public Result<string> FindTokenHash(string lookupHash)
    {
        var refreshToken = FindRefreshToken(lookupHash);

        if (refreshToken is null)
        {
            return RefreshProblems.TokenNotFound;
        }

        if (refreshToken.IsRevoked)
        {
            Revoke();

            return RefreshProblems.TokenReuse;
        }

        if (refreshToken.IsExpired)
        {
            return RefreshProblems.TokenExpired;
        }

        return Result.Success(refreshToken.TokenHash);
    }

    public void RevokeToken(string lookupHash)
    {
        var refreshToken = FindRefreshToken(lookupHash);

        refreshToken?.Revoke();
    }

    public void Revoke()
    {
        foreach (var refreshToken in _refreshTokens)
        {
            refreshToken.Revoke();
        }
    }

    private RefreshToken? FindRefreshToken(string lookupHash)
    {
        return _refreshTokens.FirstOrDefault(t => t.LookupHash == lookupHash);
    }
}