using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Payments.Domain;

namespace TrailStore.Payments.Infrastructure.Database.Configurations;

public class PaymentAttemptConfiguration : IEntityTypeConfiguration<PaymentAttempt>
{
    public void Configure(EntityTypeBuilder<PaymentAttempt> builder)
    {
        builder.HasKey(payment => payment.Id);
        
        builder.Property(payment => payment.Status)
            .IsRequired();

        builder.Property(payment => payment.UpdatedStatusAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()");
    }
}