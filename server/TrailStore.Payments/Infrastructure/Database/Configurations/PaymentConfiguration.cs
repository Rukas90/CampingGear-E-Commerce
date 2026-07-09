using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Payments.Domain;

namespace TrailStore.Payments.Infrastructure.Database.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(payment => payment.Id);
        
        builder.Property(payment => payment.IntentId)
            .IsRequired();
        
        builder.Property(payment => payment.Amount)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(payment => payment.CurrencyCode)
            .IsRequired();
        
        builder.Property(payment => payment.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()"); 
    }
}