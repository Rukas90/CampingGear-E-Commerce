using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Domain.RefreshTokens;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Infrastructure.Configurations;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Identity.Infrastructure.Database;

[AppService<IIdentityUnitOfWork>]
public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) 
    : BaseDbContext<IdentityDbContext>(options), IIdentityUnitOfWork
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<RefreshFamily> RefreshFamilies { get; set; }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder config)
        => DatabaseConventionConfiguration.ApplyDefaultConventions<IdentityDbContext>(config);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbDefaults.DefaultSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}