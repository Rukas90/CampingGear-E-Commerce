using Microsoft.EntityFrameworkCore;
using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Infrastructure.Configurations;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Basket.Infrastructure.Database;

[AppService<IBasketUnitOfWork>]
public sealed class BasketDbContext(DbContextOptions<BasketDbContext> options) 
    : BaseDbContext<BasketDbContext>(options), IBasketUnitOfWork
{
    protected override string DefaultSchema => DbDefaults.DefaultSchema;

    public DbSet<ShoppingSession> ShoppingSessions { get; set; }
    
    public DbSet<CartItem> CartItems { get; set; }
}