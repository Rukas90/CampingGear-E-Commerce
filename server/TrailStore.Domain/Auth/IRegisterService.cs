using TrailStore.Domain.Auth.Commands;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Auth;

public interface IRegisterService
{
    Task<Result<AuthResult>> RegisterAsync(RegisterCommand command, CancellationToken ct);
}