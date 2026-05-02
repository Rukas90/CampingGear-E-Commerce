using TrailStore.Shared.Common;

namespace TrailStore.Domain.Auth;

public interface IAuthService
{
    Task<Result<AuthResult>> RefreshSession(string? token, CancellationToken ct);
}