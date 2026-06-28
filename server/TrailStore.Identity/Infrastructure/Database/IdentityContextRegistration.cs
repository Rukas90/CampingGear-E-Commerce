using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Shared.Infrastructure.Constants;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Identity.Infrastructure.Database;

public static class IdentityContextRegistration
{
    public static void AddIdentityContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext>(options => 
            options.UsePostgres(configuration.GetConnectionString("DefaultConnection"), npgsql =>
            {
                npgsql.MigrationsHistoryTable(DatabaseConstants.MigrationsHistoryTable, DbDefaults.DefaultSchema);
            }));
        services.AddScoped<IIdentityUnitOfWork>(sp => sp.GetRequiredService<IdentityDbContext>());
    }
}