using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Inventory.Application.Abstractions;
using TrailStore.Shared.Infrastructure.Extensions;

namespace TrailStore.Inventory.Infrastructure.Database;

public static class InventoryContextRegistration
{
    public static void AddInventoryContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddModuleDbContext<InventoryDbContext, IInventoryUnitOfWork, IInventoryOutbox>(configuration, DbDefaults.DefaultSchema);
}