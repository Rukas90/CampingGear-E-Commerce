using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;
using TrailStore.Domain.Orders;

namespace TrailStore.Infrastructure.Data.Config;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(order => order.Id);

        builder.Property(order => order.Status)
            .IsRequired();
        
        builder.Property(review => review.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()");
        
        builder.Property(o => o.EmailAddress)
            .HasMaxLength(254)
            .IsRequired();

        builder.OwnsOne(o => o.ShippingAddress, ConfigureAddress);
            
        builder.OwnsOne(o => o.BillingAddress,  ConfigureAddress);
        
        builder.HasOne(o => o.Customer)
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
    
    private static void ConfigureAddress(OwnedNavigationBuilder<Order, PostalAddress> b)
    {
        b.Property(a => a.CountryCode).HasMaxLength(2).IsRequired();
        b.Property(a => a.RecipientName).HasMaxLength(100).IsRequired();
        b.Property(a => a.Company).HasMaxLength(100);
        b.Property(a => a.AddressLine1).HasMaxLength(200).IsRequired();
        b.Property(a => a.AddressLine2).HasMaxLength(200);
        b.Property(a => a.City).HasMaxLength(100).IsRequired();
        b.Property(a => a.Region).HasMaxLength(100);
        b.Property(a => a.PostalCode).HasMaxLength(20).IsRequired();
        b.Property(a => a.PhoneNumber).HasMaxLength(35).IsRequired();
    }
}