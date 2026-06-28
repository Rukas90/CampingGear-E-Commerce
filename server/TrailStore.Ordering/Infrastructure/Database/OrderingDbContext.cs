using Microsoft.EntityFrameworkCore;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Ordering.Infrastructure.Database;

public sealed class OrderingDbContext(DbContextOptions<OrderingDbContext> options) 
    : BaseDbContext<OrderingDbContext>(options), IOrderingUnitOfWork
{
    protected override string DefaultSchema => DbDefaults.DefaultSchema;

    public DbSet<CheckoutSession> CheckoutSessions { get; set; }
}