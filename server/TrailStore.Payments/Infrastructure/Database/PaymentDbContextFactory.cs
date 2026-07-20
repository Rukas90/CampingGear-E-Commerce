using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Payments.Infrastructure.Database;

// ReSharper disable once UnusedType.Global
public class PaymentDbContextFactory : ModuleDbContextFactory<PaymentDbContext>
{
    protected override string Schema => DbDefaults.DefaultSchema;
    protected override PaymentDbContext CreateContext(DbContextOptions<PaymentDbContext> options) => new(options);
}