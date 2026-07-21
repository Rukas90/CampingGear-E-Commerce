using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Catalog.Domain.Products;

namespace TrailStore.Catalog.Infrastructure.Database.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(brand => brand.Id);

        builder.Property(brand => brand.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(brand => brand.Description)
            .HasMaxLength(500);

        builder.Property(brand => brand.Slug)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasIndex(brand => brand.Slug)
            .IsUnique();

        builder.Property(brand => brand.LogoUrl)
            .HasMaxLength(400)
            .IsRequired();

        builder.Property(brand => brand.WebsiteUrl)
            .HasMaxLength(400)
            .IsRequired();
    }
}