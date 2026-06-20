using TrailStore.Identity.Api.Application.Abstractions;
using TrailStore.Identity.Api.Application.Contracts;
using TrailStore.Identity.Api.Domain.Auth;
using TrailStore.Identity.Api.Domain.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Api.Infrastructure.Auth;

[AppService<IAuthService>]
public class AuthService(
    IJwtService jwtService, 
    IRefreshService refreshService,
    IPasswordHasher passwordHasher,
    IUserRepository userRepository) : IAuthService
{
    public async Task<Result<User>> RegisterNewUser(string email, string password, CancellationToken ct)
    {
        var userExistsByEmail = await userRepository.ExistsByEmailAsync(email, ct);

        if (userExistsByEmail)
        {
            return UserProblems.ExistsByEmail(email);
        }

        var hashedPassword = passwordHasher.Hash(password);
        var newUser = User.Create(email, hashedPassword);
        
        userRepository.Add(newUser);
        
        return newUser;
    }

    public async Task<Result<AuthResult>> LoginWithCredentials(string email, string password, CancellationToken ct)
    {
        var user = await userRepository.FindByEmailAsync(email, ct);

        if (user is null)
        {
            return AuthProblems.InvalidCredentials;
        }
        
        var isPasswordValid = passwordHasher.Verify(password, user.PasswordHash);

        if (!isPasswordValid)
        {
            return AuthProblems.InvalidCredentials;
        }

        return new AuthResult(CreateSession(user), new UserAccount(user.Id, user.Email));
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
        
        return new AuthResult(CreateSession(user), new UserAccount(user.Id, user.Email));
    }

    private static string CreateBlacklistKey(string jti)
        => $"revoked-jti:{jti}";

    public TokenPair CreateSession(User user)
    {
        var family = refreshService.CreateNewFamily(user);

        var accessToken = jwtService.GenerateAccessToken(user);
        var refreshToken = refreshService.CreateNewToken(family);

        return new TokenPair(accessToken, refreshToken);
    }
}