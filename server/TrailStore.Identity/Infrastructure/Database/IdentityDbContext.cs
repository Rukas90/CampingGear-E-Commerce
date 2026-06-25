using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Domain.RefreshTokens;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Identity.Infrastructure.Database;

[AppService<IIdentityUnitOfWork>]
public sealed class IdentityDbContext(DbContextOptions<IdentityDbContext> options) 
    : BaseDbContext<IdentityDbContext>(options), IIdentityUnitOfWork
{
    protected override string DefaultSchema => DbDefaults.DefaultSchema;
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<RefreshFamily> RefreshFamilies { get; set; }
}