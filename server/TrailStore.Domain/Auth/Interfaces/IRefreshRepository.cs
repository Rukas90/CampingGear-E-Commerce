using TrailStore.Domain.Auth.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Auth.Interfaces;

public interface IRefreshRepository
{
    Task<RefreshToken> CreateAsync(RefreshToken token, CancellationToken ct);

    Task<RefreshToken?> GetByLookupHashAsync(string lookupHash, CancellationToken ct);

    Task RevokeFamily(Id<RefreshTokenFamily> familyId, CancellationToken ct);

    Task RevokeToken(Id<RefreshToken> id, CancellationToken ct);
}