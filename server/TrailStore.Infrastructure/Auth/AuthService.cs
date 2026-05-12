using TrailStore.Domain.Auth.Interfaces;
using TrailStore.Domain.Auth.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Auth;

[AppService<IAuthService>]
public class AuthService(IJwtService jwtService, IRefreshService refreshService, IRefreshRepository refreshRepository)
    : IAuthService
{
    public async Task<Result<AuthResult>> RefreshSession(string? token, CancellationToken ct)
    {
        var validation = await refreshService.ValidateToken(token, ct);

        if (!validation.IsSuccess) return validation.Problem;
        var refreshToken = validation.Value;

        await refreshRepository.RevokeToken(refreshToken.Id, ct);

        var customer = refreshToken.Customer;

        var accessToken = jwtService.GenerateAccessToken(customer);
        var newRefreshToken = await refreshService.GenerateToken(customer.Id, refreshToken.FamilyId, ct);

        return new AuthResult(customer, new AuthTokens(accessToken, newRefreshToken));
    }
}