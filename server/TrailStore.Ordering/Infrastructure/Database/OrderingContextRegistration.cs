using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Shared.Infrastructure.Constants;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Ordering.Infrastructure.Database;

public static class OrderingContextRegistration
{
    public static void AddOrderingContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrderingDbContext>(options => 
            options.UsePostgres(configuration.GetConnectionString("DefaultConnection"), npgsql =>
            {
                npgsql.MigrationsHistoryTable(DatabaseConstants.MigrationsHistoryTable, DbDefaults.DefaultSchema);
            }));
        services.AddScoped<IOrderingUnitOfWork>(sp => sp.GetRequiredService<OrderingDbContext>());
    }
}