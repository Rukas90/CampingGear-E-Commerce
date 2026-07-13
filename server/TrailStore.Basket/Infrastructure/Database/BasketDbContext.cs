using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Basket.Infrastructure.Database;

public sealed class BasketDbContext(DbContextOptions<BasketDbContext> options) 
    : BaseDbContext<BasketDbContext>(options), IBasketUnitOfWork
{
    protected override string DefaultSchema => DbDefaults.DefaultSchema;

    public DbSet<Cart> Carts { get; set; }
    
    public DbSet<CartItem> CartItems { get; set; }
    
    protected override Assembly[] AdditionalConfigurationAssemblies()
    {
        return [
            typeof(SkuRef).Assembly,
            typeof(UserRef).Assembly
        ];
    }
}