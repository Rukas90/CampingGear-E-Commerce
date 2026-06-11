using TrailStore.Domain.Auth.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Auth.Interfaces;

public interface IRefreshRepository
{
    RefreshToken Add(RefreshToken token);
    
    Task<RefreshToken?> FindByLookupHashAsync(string lookupHash, CancellationToken ct);

    Task RevokeFamily(Id<RefreshTokenFamily> familyId, CancellationToken ct);
}