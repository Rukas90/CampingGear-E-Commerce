using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Ordering.Domain.Shipping;

namespace TrailStore.Ordering.Infrastructure.Database.Configurations;

public class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethod>
{
    public void Configure(EntityTypeBuilder<ShippingMethod> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Code)
            .IsRequired();

        builder.Property(r => r.Name)
            .IsRequired();
        
        builder.Property(r => r.Description)
            .IsRequired();
        
        builder.Property(r => r.FlatFee)
            .IsRequired();
        
        builder.Property(r => r.FreeShippingThreshold)
            .IsRequired();
        
        builder.HasOne(method => method.Zone)
            .WithMany(zone => zone.Methods)
            .HasForeignKey(method => method.ZoneId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}