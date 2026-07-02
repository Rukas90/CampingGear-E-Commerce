using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Ordering.Infrastructure.Orders;

namespace TrailStore.Ordering.Infrastructure.Database.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(order => order.Id);

        builder.Property(order => order.Token)
            .IsRequired()
            .HasMaxLength(OrderTokenization.Length)
            .IsFixedLength();
        
        builder.HasIndex(order => order.Token)
            .IsUnique();
        
        builder.Property(order => order.Status)
            .IsRequired();
        
        builder.Property(order => order.StatusUpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()"); 

        builder.Property(order => order.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()");

        builder.Property(order => order.Subtotal)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(order => order.TaxAmount)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(order => order.TotalPrice)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.HasOne(order => order.Shipping)
            .WithOne()
            .HasForeignKey<OrderShipping>(shipping => shipping.OrderId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(order => order.Items)
            .WithOne()
            .HasForeignKey(item => item.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(order => order.Payments)
            .WithOne(payment => payment.Order)
            .HasForeignKey(payment => payment.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.OwnsOne(order => order.BillingAddress, PostalAddressConfigBuilder.ConfigureAddress);
    }
}