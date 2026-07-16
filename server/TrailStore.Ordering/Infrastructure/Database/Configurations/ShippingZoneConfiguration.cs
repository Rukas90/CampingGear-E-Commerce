using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Ordering.Domain.Shipping;

namespace TrailStore.Ordering.Infrastructure.Database.Configurations;

public class ShippingZoneConfiguration : IEntityTypeConfiguration<ShippingZone>
{
    public void Configure(EntityTypeBuilder<ShippingZone> builder)
    {
        builder.HasKey(zone => zone.Id);

        builder.Property(zone => zone.Name)
            .IsRequired();
        
        builder.Property(zone => zone.CountryCodes)
            .IsRequired();
    }
}