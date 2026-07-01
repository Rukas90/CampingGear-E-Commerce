using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Inventory.Domain;

namespace TrailStore.Inventory.Infrastructure.Database.Configurations;

public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.SkuId)
            .IsUnique();
        
        builder.Property(c => c.SkuId)
            .IsRequired();
        
        builder.Property(c => c.Stock)
            .IsRequired();
        
        builder.Property(c => c.Reserved)
            .IsRequired();
    }
}