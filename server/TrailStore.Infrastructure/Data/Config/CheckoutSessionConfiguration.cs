
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
        
        builder.OwnsOne(order => order.ShippingAddress, PostalAddressConfigBuilder.ConfigureAddress);
        
        builder.OwnsOne(order => order.BillingAddress, PostalAddressConfigBuilder.ConfigureAddress);
    }
}