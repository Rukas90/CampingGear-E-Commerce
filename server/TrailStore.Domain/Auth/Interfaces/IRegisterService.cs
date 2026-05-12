using TrailStore.Domain.Auth.Commands;
using TrailStore.Domain.Auth.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Auth.Interfaces;

public interface IRegisterService
{
    Task<Result<AuthResult>> RegisterAsync(RegisterCommand command, CancellationToken ct);
}