using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Ordering.Domain.Shipping;

namespace TrailStore.Ordering.Infrastructure.Database.Configurations;

public class ShippingZoneConfiguration : IEntityTypeConfiguration<ShippingZone>
{
    public void Configure(EntityTypeBuilder<ShippingZone> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired();
        
        builder.Property(r => r.CountryCodes)
            .IsRequired();
    }
}