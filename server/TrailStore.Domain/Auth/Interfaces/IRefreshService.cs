using TrailStore.Domain.Auth.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Auth.Interfaces;

public interface IRefreshService
{
    Task<string> GenerateToken(Id<Customer> customerId, Id<RefreshTokenFamily>? familyId = null,
        CancellationToken ct = default);

    Task<Result<RefreshToken>> ValidateToken(string? token, CancellationToken ct);

    Task<Result<RefreshToken>> FindRefreshToken(string token, CancellationToken ct);
}