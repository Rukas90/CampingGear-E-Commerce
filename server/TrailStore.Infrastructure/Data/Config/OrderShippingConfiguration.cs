using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Infrastructure.Data.Config;

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
        
        builder.Property(shipping => shipping.Price)
            .IsRequired();
        
        builder.OwnsOne(shipping => shipping.Address, PostalAddressConfigBuilder.ConfigureAddress);
    }
}