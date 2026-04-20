using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(address => address.Id);
        
        builder.Property(address => address.CountryCode)
            .HasMaxLength(2)
            .IsRequired();
        
        builder.Property(address => address.RecipientName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(address => address.Company)
            .HasMaxLength(100);
        
        builder.Property(address => address.AddressLine1)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(address => address.AddressLine2)
            .HasMaxLength(200);
        
        builder.Property(address => address.City)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(address => address.Region)
            .HasMaxLength(100);
        
        builder.Property(address => address.PostalCode)
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(address => address.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(address => address.IsDefault)
            .IsRequired();
        
        builder.HasOne(address => address.Customer)
            .WithMany(customer => customer.Addresses)
            .HasForeignKey(address => address.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}