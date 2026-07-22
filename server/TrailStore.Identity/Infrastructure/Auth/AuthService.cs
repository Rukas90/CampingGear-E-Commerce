using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Application.Results;
using TrailStore.Identity.Domain.Auth;
using TrailStore.Identity.Domain.RefreshTokens;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Infrastructure.Auth;

[AppService<IAuthService>]
public class AuthService(
    IJwtService jwtService, 
    IRefreshService refreshService,
    IPasswordHasher passwordHasher,
    IUserRepository userRepository) : IAuthService
{
    public User RegisterNewUser(string email, string? password)
    {
        var hashedPassword = password is not null ? passwordHasher.Hash(password) : null;
        var newUser = User.Create(email, hashedPassword);
        
        userRepository.Add(newUser);
        
        return newUser;
    }

    public async Task<Result<AuthResult>> LoginWithCredentials(string email, string password, CancellationToken ct)
    {
        var user = await userRepository.FindByEmailAsync(email, ct);

        if (user?.PasswordHash is null)
        {
            return AuthProblems.InvalidCredentials;
        }
        
        var isPasswordValid = passwordHasher.Verify(password, user.PasswordHash);

        if (!isPasswordValid)
        {
            return AuthProblems.InvalidCredentials;
        }

        var tokenPair = CreateSession(user);

        return new AuthResult(tokenPair, new UserAccountResult(user.Id, user.Email));
    }

    public async Task<Result<AuthResult>> RefreshSession(string token, CancellationToken ct)
    {
        var validation = await refreshService.ValidateToken(token, ct);

        if (!validation.IsSuccess)
        {
            return validation.Problem;
        }
        
        var family = validation.Value;
        var user = await userRepository.FindAsync(family.UserId, ct);

        if (user is null)
        {
            family.Revoke();
            
            return AuthProblems.InvalidCredentials;
        }

        refreshService.RevokeToken(family, token);
        
        var tokenPair = CreateSession(user, family);
        
        return new AuthResult(tokenPair, new UserAccountResult(user.Id, user.Email));
    }

    public TokenPairResult CreateSession(User user, RefreshFamily? family = null)
    {
        family ??= refreshService.CreateNewFamily(user);

        var accessToken = jwtService.GenerateAccessToken(user);
        var refreshToken = refreshService.CreateNewToken(family);

        return new TokenPairResult(accessToken, refreshToken);
    }
}