using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Basket.Application.Abstractions;
using TrailStore.Shared.Infrastructure.Constants;
using TrailStore.Shared.Infrastructure.Extensions;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Basket.Infrastructure.Database;

public static class BasketContextRegistration
{
    public static void AddBasketContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddModuleDbContext<BasketDbContext, IBasketUnitOfWork>(configuration, DbDefaults.DefaultSchema);
}