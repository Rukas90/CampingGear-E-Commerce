using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Ordering.Domain.Checkout;

namespace TrailStore.Ordering.Infrastructure.Database.Configurations;

public class SavedCheckoutDetailsConfiguration : IEntityTypeConfiguration<SavedCheckoutDetails>
{
    public void Configure(EntityTypeBuilder<SavedCheckoutDetails> builder)
    {
        builder.HasKey(details => details.Id);
        
        builder.Property(details => details.UserId)
            .IsRequired();
        
        builder.Property(details => details.EmailAddress)
            .HasMaxLength(256).IsRequired();
        
        builder.Property(details => details.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()");
        
        builder.OwnsOne(details => details.ShippingAddress, PostalAddressConfigBuilder.ConfigureAddress);
        
        builder.OwnsOne(details => details.BillingAddress, PostalAddressConfigBuilder.ConfigureAddress);
    }
}