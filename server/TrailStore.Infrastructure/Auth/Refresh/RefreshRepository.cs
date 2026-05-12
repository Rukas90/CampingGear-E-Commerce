using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Auth.Interfaces;
using TrailStore.Domain.Auth.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Auth.Refresh;

[AppService<IRefreshRepository>]
public class RefreshRepository(AppDbContext context) : IRefreshRepository
{
    public async Task<RefreshToken> CreateAsync(RefreshToken token, CancellationToken ct)
    {
        await context.RefreshTokens.AddAsync(token, ct);
        await context.SaveChangesAsync(ct);

        return token;
    }

    public Task<RefreshToken?> GetByLookupHashAsync(string lookupHash, CancellationToken ct)
    {
        return context.RefreshTokens.Include(token => token.Customer).FirstOrDefaultAsync(
            token => token.LookupHash == lookupHash, ct);
    }

    public Task RevokeFamily(Id<RefreshTokenFamily> familyId, CancellationToken ct)
    {
        return context.RefreshTokens
            .Where(token => token.FamilyId == familyId)
            .ExecuteUpdateAsync(s => s.SetProperty(token => token.RevokedAt, DateTime.UtcNow), ct);
    }

    public Task RevokeToken(Id<RefreshToken> id, CancellationToken ct)
    {
        return context.RefreshTokens
            .Where(token => token.Id == id)
            .ExecuteUpdateAsync(s => s.SetProperty(token => token.RevokedAt, DateTime.UtcNow), ct);
    }
}