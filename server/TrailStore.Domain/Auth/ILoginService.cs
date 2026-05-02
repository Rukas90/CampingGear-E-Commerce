using TrailStore.Domain.Auth.Commands;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Auth;

public interface ILoginService
{
    Task<Result<AuthResult>> Login(LoginCommand command, CancellationToken ct);

    Task<AuthTokens> CreateAuthTokens(Customer customer, CancellationToken ct);
}