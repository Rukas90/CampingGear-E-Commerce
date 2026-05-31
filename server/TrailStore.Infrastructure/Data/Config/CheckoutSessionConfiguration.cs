
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class CheckoutSessionConfiguration : IEntityTypeConfiguration<CheckoutSession>
{
    public void Configure(EntityTypeBuilder<CheckoutSession> builder)
    {
        builder.HasKey(session => session.Id);
        
        builder.Property(session => session.SessionId)
            .IsRequired();

        builder.Property(session => session.EmailAddress)
            .HasMaxLength(256);
        
        builder.Property(session => session.Status)
            .IsRequired();

        builder.Property(review => review.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()");
        
        builder.OwnsOne(session => session.ShippingAddress, PostalAddressConfigBuilder.ConfigureAddress);
        
        builder.OwnsOne(session => session.BillingAddress, PostalAddressConfigBuilder.ConfigureAddress);
        
        builder.HasOne(session => session.ShippingMethod)
            .WithMany()
            .HasForeignKey(session => session.ShippingMethodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}