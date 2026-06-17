using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Domain.Users;
using TrailStore.Identity.Infrastructure.Data;
using TrailStore.Shared.DependencyInjection;
using TrailStore.Shared.Seeding;

namespace TrailStore.Identity.Seed;

[AppService<ISeedRunner>]
public class IdentitySeedRunner(IdentityDbContext context) : SeedRunner
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