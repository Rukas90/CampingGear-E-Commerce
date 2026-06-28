using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Basket.Application.Abstractions;
using TrailStore.Shared.Infrastructure.Constants;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Basket.Infrastructure.Database;

public static class BasketContextRegistration
{
    public static void AddBasketContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BasketDbContext>(options => 
            options.UsePostgres(configuration.GetConnectionString("DefaultConnection"), npgsql =>
            {
                npgsql.MigrationsHistoryTable(DatabaseConstants.MigrationsHistoryTable, DbDefaults.DefaultSchema);
            }));
        services.AddScoped<IBasketUnitOfWork>(sp => sp.GetRequiredService<BasketDbContext>());
    }
}