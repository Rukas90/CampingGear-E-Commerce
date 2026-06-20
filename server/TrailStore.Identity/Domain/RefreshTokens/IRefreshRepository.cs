using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Api.Domain.RefreshTokens;

public interface IRefreshRepository : IAggregateRepository<RefreshFamily>
{
    Task<RefreshFamily?> FindByLookupHashAsync(string lookupHash, CancellationToken ct);
}