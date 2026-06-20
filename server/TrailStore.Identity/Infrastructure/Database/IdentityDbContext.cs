using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Api.Application.Abstractions;
using TrailStore.Identity.Api.Domain.RefreshTokens;
using TrailStore.Identity.Api.Domain.Users;
using TrailStore.Shared.Infrastructure.Conversions;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Identity.Api.Infrastructure.Database;

[AppService<IIdentityUnitOfWork>]
public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) 
    : BaseDbContext<IdentityDbContext>(options)
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<RefreshFamily> RefreshFamilies { get; set; }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder config)
    {
        IdConfigConversions.ConfigureIdConversion(config, typeof(IdentityDbContext).Assembly);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("identity");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}