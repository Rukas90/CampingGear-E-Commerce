using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Identity.Infrastructure.Data;

public static class IdentityContextRegistration
{
    public static void AddIdentityContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext>(options => 
            options.UsePostgres(configuration.GetConnectionString("DefaultConnection"), npgsql =>
            {
                npgsql.MigrationsHistoryTable("__EFMigrationsHistory", "identity");
            }));
    }
}