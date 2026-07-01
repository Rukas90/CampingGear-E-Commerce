using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Ordering.Domain.Orders;

namespace TrailStore.Ordering.Infrastructure.Database.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(item => item.Id);

        builder.Property(item => item.Quantity)
            .IsRequired();

        builder.Property(item => item.UnitPrice)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(item => item.TaxRate)
            .HasPrecision(18, 4)
            .IsRequired();
        
        builder.Property(item => item.TaxAmount)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(item => item.PriceBeforeTax)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(item => item.PriceAfterTax)
            .HasPrecision(18, 2)
            .IsRequired();
    }
}