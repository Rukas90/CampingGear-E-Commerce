using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Catalog.Domain.Skus;

namespace TrailStore.Catalog.Infrastructure.Database.Configurations;

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
        builder.HasIndex(sku => sku.UnitPrice);

        builder.Property(sku => sku.Stock)
            .IsRequired();
        builder.HasIndex(sku => sku.Stock);

        builder.HasOne(sku => sku.Product)
            .WithMany(product => product.Skus)
            .HasForeignKey(sku => sku.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(sku => sku.Options)
            .WithMany()
            .UsingEntity(typeBuilder => typeBuilder.ToTable("SkuOptions"));
    }
}