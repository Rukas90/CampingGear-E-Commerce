using TrailStore.Identity.Domain.RefreshTokens;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Abstractions;

public interface IRefreshService
{
    RefreshFamily CreateNewFamily(User user);
    
    Task<Result<RefreshFamily>> ValidateToken(string token, CancellationToken ct);

    void RevokeToken(RefreshFamily family, string token);
    
    string CreateNewToken(RefreshFamily family);

    Task<Result> RevokeTokenFamily(string token, CancellationToken ct);
}