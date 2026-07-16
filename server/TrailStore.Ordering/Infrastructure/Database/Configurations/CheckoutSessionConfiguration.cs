using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Ordering.Domain.Checkout;

namespace TrailStore.Ordering.Infrastructure.Database.Configurations;

public class CheckoutSessionConfiguration : IEntityTypeConfiguration<CheckoutSession>
{
    public void Configure(EntityTypeBuilder<CheckoutSession> builder)
    {
        builder.HasKey(session => session.Id);
        
        builder.Property(session => session.CartId)
            .IsRequired();

        builder.Property(session => session.EmailAddress)
            .HasMaxLength(256);
        
        builder.Property(session => session.Status)
            .IsRequired();
        
        builder.ToTable(session => session.HasCheckConstraint(
            "CK_CheckoutSessions_EmailRequiredForUser",
            "\"UserId\" IS NULL OR \"EmailAddress\" IS NOT NULL"));

        builder.Property(session => session.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()");
        
        builder.OwnsOne(session => session.ShippingAddress, PostalAddressConfigBuilder.ConfigureAddress);
        
        builder.OwnsOne(session => session.BillingAddress, PostalAddressConfigBuilder.ConfigureAddress);
    }
}