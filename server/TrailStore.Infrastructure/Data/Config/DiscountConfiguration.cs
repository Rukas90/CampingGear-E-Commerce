using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(d => d.Id);
        
        builder.Property(d => d.Type)
            .HasConversion<string>()
            .IsRequired();
        
        builder.Property(d => d.Value)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.HasOne(d => d.Sku)
            .WithMany()
            .HasForeignKey(d => d.SkuId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}