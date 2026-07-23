using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TrailStore.Inventory.Application.Abstractions;
using TrailStore.Inventory.Domain;
using TrailStore.Shared.Domain.Messages;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Inventory.Infrastructure.Database;

public sealed class InventoryDbContext(DbContextOptions<InventoryDbContext> options)
    : BaseDbContext<InventoryDbContext>(options), IInventoryUnitOfWork, IInventoryOutbox
{
    protected override string DefaultSchema => DbDefaults.DefaultSchema;
    
    public DbSet<InventoryItem> InventoryItems { get; set; }
    
    public DbSet<OutboxMessage> Messages { get; set; }
    
    protected override Assembly[] AdditionalConfigurationAssemblies()
        => [
            typeof(OutboxMessage).Assembly
        ];
}