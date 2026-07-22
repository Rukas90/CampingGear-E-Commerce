using TrailStore.Identity.Application.Results;
using TrailStore.Identity.Domain.RefreshTokens;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Abstractions;

public interface IAuthService
{
    User RegisterNewUser(string email, string? password);
    
    Task<Result<AuthResult>> LoginWithCredentials(string email, string password, CancellationToken ct);
    
    Task<Result<AuthResult>> RefreshSession(string token, CancellationToken ct);
    
    TokenPairResult CreateSession(User user, RefreshFamily? family = null);
}