using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Ordering.Domain.Orders;

namespace TrailStore.Ordering.Infrastructure.Database.Configurations;

public class OrderShippingConfiguration : IEntityTypeConfiguration<OrderShipping>
{
    public void Configure(EntityTypeBuilder<OrderShipping> builder)
    {
        builder.HasKey(shipping => shipping.Id);
        
        builder.Property(shipping => shipping.OrderId)
            .IsRequired();
        
        builder.Property(shipping => shipping.MethodCode)
            .IsRequired();
        
        builder.Property(shipping => shipping.MethodName)
            .IsRequired();
        
        builder.Property(shipping => shipping.PriceBeforeTax)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(shipping => shipping.TaxAmount)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(shipping => shipping.PriceAfterTax)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.OwnsOne(shipping => shipping.Address, PostalAddressConfigBuilder.ConfigureAddress);
    }
}