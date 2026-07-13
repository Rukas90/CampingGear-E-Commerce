using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Identity.Domain.Users;
using TrailStore.Identity.Infrastructure.Database;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Identity.Infrastructure.Users;

[AppService<IUserRepository>]
public class UserRepository(IdentityDbContext _context) 
    : AggregateRepository<User, IdentityDbContext>(_context), IUserRepository
{
    public Task<UserProfileSnapshot?> GetProfileAsync(Id<User> id, CancellationToken ct)
        => ReadQuery
            .Where(user => user.Id == id)
            .Select(ToProfileSnapshot)
            .SingleOrDefaultAsync(ct);

    public Task<UserProfileSnapshot[]> GetProfilesAsync(Id<User>[] ids, CancellationToken ct)
        => ReadQuery
            .Where(user => ids.Any(id => id == user.Id))
            .Select(ToProfileSnapshot)
            .ToArrayAsync(ct);

    private static readonly Expression<Func<User, UserProfileSnapshot>> ToProfileSnapshot = user =>
        new UserProfileSnapshot(
            new Id<UserRef>(user.Id),
            user.Email,
            user.FirstName ?? string.Empty,
            user.LastName ?? string.Empty); 
    
    public async Task<User?> FindByEmailAsync(string email, CancellationToken ct)
        => await AggregateWriteQuery.Where(u => u.Email == email).SingleOrDefaultAsync(ct);

    public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
        => ReadQuery.AnyAsync(user => user.Email == email, ct);

    protected override IQueryable<User> BuildAggregateQuery(DbSet<User> set) => set;
}