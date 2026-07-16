using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Domain.Messages;
using TrailStore.Shared.Infrastructure.Outbox;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Ordering.Infrastructure.Database;

public sealed class OrderingDbContext(DbContextOptions<OrderingDbContext> options) 
    : BaseDbContext<OrderingDbContext>(options), IOrderingUnitOfWork, IOrderingOutbox
{
    protected override string DefaultSchema => DbDefaults.DefaultSchema;

    public DbSet<CheckoutSession> CheckoutSessions { get; set; }
    
    public DbSet<SavedCheckoutDetails> SavedCheckoutDetails { get; set; }
    
    public DbSet<ShippingMethod> ShippingMethods { get; set; }
    
    public DbSet<ShippingZone> ShippingZones { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderItem> OrderItems { get; set; }
    
    public DbSet<OrderShipping> OrderShippings { get; set; }

    public DbSet<OutboxMessage> Messages { get; set; }
    
    protected override Assembly[] AdditionalConfigurationAssemblies()
        => [
            typeof(CartRef).Assembly,
            typeof(UserRef).Assembly,
            typeof(SkuRef).Assembly,
            typeof(OutboxMessage).Assembly
        ];

    public void Enqueue<TEvent>(TEvent evt) where TEvent : IntegrationEvent
        => Messages.Add(OutboxMessage.Create(evt));

    public IOutboxMessages GetMessages()
        => new OutboxMessages(Messages);
}