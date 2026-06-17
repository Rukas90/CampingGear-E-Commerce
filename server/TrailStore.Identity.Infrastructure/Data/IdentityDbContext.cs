using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Domain;
using TrailStore.Identity.Domain.RefreshTokens;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.DependencyInjection;
using TrailStore.Shared.Infrastructure.Conversions;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Identity.Infrastructure.Data;

[AppService<IIdentityUnitOfWork>]
public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) 
    : BaseDbContext<IdentityDbContext>(options)
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<RefreshFamily> RefreshFamilies { get; set; }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder config)
    {
        IdConfigConversions.ConfigureIdConversion(config, IdentityDomainAssembly.Reference);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("identity");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}