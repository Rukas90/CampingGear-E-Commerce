using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Domain.RefreshTokens;
using TrailStore.Identity.Infrastructure.Database;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Identity.Infrastructure.Refresh;

[AppService<IRefreshRepository>]
public class RefreshRepository(IdentityDbContext context) 
    : AggregateRepository<RefreshFamily, IdentityDbContext>(context), IRefreshRepository
{
    public Task<RefreshFamily?> FindByLookupHashAsync(string lookupHash, CancellationToken ct)
        => AggregateWriteQuery
            .Where(family => family.RefreshTokens.Any(token => token.LookupHash == lookupHash))
            .SingleOrDefaultAsync(ct);

    protected override IQueryable<RefreshFamily> BuildAggregateQuery(DbSet<RefreshFamily> set)
        => set.Include(family => family.RefreshTokens);
}