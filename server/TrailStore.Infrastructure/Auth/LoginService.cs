using TrailStore.Domain.Auth.Commands;
using TrailStore.Domain.Auth.Errors;
using TrailStore.Domain.Auth.Interfaces;
using TrailStore.Domain.Auth.Models;
using TrailStore.Domain.Customers.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Shared;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Auth;

[AppService<ILoginService>]
public class LoginService(
    ICustomerRepository customerRepository,
    IPasswordHasher passwordHasher,
    IJwtService jwtService,
    IRefreshService refreshService) : ILoginService
{
    public async Task<Result<AuthResult>> Login(LoginCommand command, CancellationToken ct)
    {
        var customer = await customerRepository.GetByEmailAsync(command.Email, ct);

        if (customer is null || !passwordHasher.Verify(command.Password, customer.PasswordHash))
            return AuthProblems.InvalidCredentials;

        return new AuthResult(customer, await CreateAuthTokens(customer, ct));
    }

    public async Task<AuthTokens> CreateAuthTokens(Customer customer, CancellationToken ct)
    {
        var accessToken = jwtService.GenerateAccessToken(customer);
        var refreshToken = await refreshService.GenerateToken(customer.Id, null, ct);

        return new AuthTokens(accessToken, refreshToken);
    }
}