using TrailStore.Identity.Application.Contracts;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Abstractions;

public interface IAuthService
{
    Task<Result<User>> RegisterNewUser(string email, string password, CancellationToken ct);
    
    Task<Result<AuthResult>> LoginWithCredentials(string email, string password, CancellationToken ct);
    
    Task<Result<AuthResult>> RefreshSession(string token, CancellationToken ct);
    
    TokenPair CreateSession(User user);
}