using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Domain.Users;
using TrailStore.Identity.Infrastructure.Database;
using TrailStore.Seed.Data;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Seeding;

namespace TrailStore.Seed.Runners;

[AppService<ISeedRunner>]
internal class IdentitySeedRunner(IdentityDbContext context) : SeedRunner
{
    public override string Identifier => "Identity";
    
    protected override void Clear()
    {
        context.Users.RemoveRange(
            context.Users.Where(c => c.PasswordHash == SeedDefaults.NO_LOGIN_HASH)); 
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