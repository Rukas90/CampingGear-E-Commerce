using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Auth;

public interface IRefreshService
{
    Task<string> GenerateToken(Id<Customer> customerId, Id<RefreshTokenFamily>? familyId = null, CancellationToken ct = default);
    
    Task<Result<RefreshToken>> ValidateToken(string? token, CancellationToken ct);

    Task<Result<RefreshToken>> FindRefreshToken(string token, CancellationToken ct);
}