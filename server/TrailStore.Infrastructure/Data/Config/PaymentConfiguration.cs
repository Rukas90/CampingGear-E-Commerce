using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(payment => payment.Id);
        
        builder.Property(payment => payment.IntentId)
            .IsRequired();
        
        builder.Property(payment => payment.Amount)
            .IsRequired();
        
        builder.Property(payment => payment.CurrencyCode)
            .IsRequired();
        
        builder.Property(payment => payment.Status)
            .IsRequired();
        
        builder.Property(order => order.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()"); 

        builder.Property(review => review.UpdatedStatusAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()");
    }
}