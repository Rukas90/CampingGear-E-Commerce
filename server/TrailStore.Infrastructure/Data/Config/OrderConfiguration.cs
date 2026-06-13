using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(order => order.Id);

        builder.Property(order => order.Token)
            .IsRequired()
            .HasMaxLength(32)
            .IsFixedLength();
        
        builder.HasIndex(order => order.Token)
            .IsUnique();
        
        builder.Property(order => order.Status)
            .IsRequired();
        
        builder.Property(order => order.StatusUpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()"); 

        builder.Property(review => review.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()");

        builder.HasOne(o => o.Customer)
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(o => o.Shipping)
            .WithOne()
            .HasForeignKey<OrderShipping>(s => s.OrderId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(order => order.TotalPrice)
            .IsRequired();
        
        builder.HasMany(order => order.Payments)
            .WithOne(payment => payment.Order)
            .HasForeignKey(payment => payment.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.OwnsOne(order => order.BillingAddress, PostalAddressConfigBuilder.ConfigureAddress);
    }
}