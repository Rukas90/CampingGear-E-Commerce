using Microsoft.EntityFrameworkCore;
using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Payments.Infrastructure.Database;

public class PaymentDbContext(DbContextOptions<PaymentDbContext> options)
    : BaseDbContext<PaymentDbContext>(options), IPaymentUnitOfWork
{
    protected override string DefaultSchema => DbDefaults.DefaultSchema;
    
    public DbSet<Payment> Payments { get; set; }
}