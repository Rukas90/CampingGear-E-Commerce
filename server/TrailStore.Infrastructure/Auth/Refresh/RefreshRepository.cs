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
    public RefreshToken Add(RefreshToken token)
    {
        context.RefreshTokens.Add(token);

        return token;
    }

    public Task<RefreshToken?> FindByLookupHashAsync(string lookupHash, CancellationToken ct)
    {
        return context.RefreshTokens.Include(token => token.Customer).FirstOrDefaultAsync(
            token => token.LookupHash == lookupHash, ct);
    }

    public async Task RevokeFamily(Id<RefreshTokenFamily> familyId, CancellationToken ct)
    {
        var refreshToken 
            = await context.RefreshTokens.Where(token => token.FamilyId == familyId).FirstOrDefaultAsync(ct);

        refreshToken?.Revoke();
    }
}