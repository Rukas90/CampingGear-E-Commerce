using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Domain.Users;
using TrailStore.Identity.Infrastructure.Database;
using TrailStore.Seed.Common;
using TrailStore.Seed.Data;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Seed.Runners;

[AppService<ISeedRunner>]
internal class IdentitySeedRunner(IdentityDbContext context) : SeedRunner
{
    public override string Identifier => "Identity";
    
    protected override async Task DeleteAsync()
    {
        await context.Users
            .Where(u => u.PasswordHash == SeedDefaults.NO_LOGIN_HASH)
            .ExecuteDeleteAsync();
    }

    protected override void Seed()
    {
        context.Users.AddRange(Discover<User>(typeof(Users).Assembly));
    }

    protected override Task Commit()
        => context.SaveChangesAsync();

    protected override Task<bool> IsSeededAsync()
        => context.Users.AnyAsync();
}