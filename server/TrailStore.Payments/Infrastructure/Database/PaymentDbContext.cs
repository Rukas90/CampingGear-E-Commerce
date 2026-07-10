using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Domain.Messages;
using TrailStore.Shared.Infrastructure.Outbox;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Payments.Infrastructure.Database;

public class PaymentDbContext(DbContextOptions<PaymentDbContext> options)
    : BaseDbContext<PaymentDbContext>(options), IPaymentUnitOfWork, IPaymentOutbox
{
    protected override string DefaultSchema => DbDefaults.DefaultSchema;
    
    public DbSet<Payment> Payments { get; set; }
    
    public DbSet<OutboxMessage> Messages { get; set; }

    protected override Assembly[] AdditionalConfigurationAssemblies()
        => [typeof(OutboxMessage).Assembly];

    public void Enqueue<TEvent>(TEvent evt) where TEvent : IntegrationEvent
        => Messages.Add(OutboxMessage.Create(evt));

    public IOutboxMessages GetMessages()
        => new OutboxMessages(Messages);
}