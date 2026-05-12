using TrailStore.Domain.Auth.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Auth.Interfaces;

public interface IAuthService
{
    Task<Result<AuthResult>> RefreshSession(string? token, CancellationToken ct);
}