using TrailStore.Domain.Auth.Commands;
using TrailStore.Domain.Auth.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Auth.Interfaces;

public interface ILoginService
{
    Task<Result<AuthResult>> Login(LoginCommand command, CancellationToken ct);

    Task<AuthTokens> CreateAuthTokens(Customer customer, CancellationToken ct);
}