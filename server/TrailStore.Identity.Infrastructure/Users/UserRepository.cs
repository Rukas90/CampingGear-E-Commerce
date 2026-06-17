using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Domain.Users;
using TrailStore.Identity.Infrastructure.Data;
using TrailStore.Shared.DependencyInjection;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Identity.Infrastructure.Users;

[AppService<IUserRepository>]
public class UserRepository(IdentityDbContext _context) 
    : AggregateRepository<User, IdentityDbContext>(_context), IUserRepository
{
    public async Task<User?> FindByEmailAsync(string email, CancellationToken ct)
        => await AggregateQuery.Where(u => u.Email == email).SingleOrDefaultAsync(ct);

    public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
        => ReadQuery.AnyAsync(user => user.Email == email, ct);

    protected override IQueryable<User> BuildAggregateQuery(DbSet<User> set)
        => set;
}