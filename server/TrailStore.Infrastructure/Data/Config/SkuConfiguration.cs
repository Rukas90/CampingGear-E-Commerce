using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class SkuConfiguration : IEntityTypeConfiguration<Sku>
{
    public void Configure(EntityTypeBuilder<Sku> builder)
    {
        builder.HasKey(sku => sku.Id);

        builder.Property(sku => sku.Code)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(sku => sku.Code)
            .IsUnique();

        builder.Property(sku => sku.UnitPrice)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(sku => sku.Stock)
            .IsRequired();

        builder.HasOne(sku => sku.Product)
            .WithMany(product => product.Skus)
            .HasForeignKey(sku => sku.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(sku => sku.Options)
            .WithMany(option => option.Skus)
            .UsingEntity(typeBuilder => typeBuilder.ToTable("SkuOptions"));
    }
}