using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Data.Config;

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
        
        builder.Property(brand => brand.LogoUrl)
            .HasMaxLength(400)
            .IsRequired();
        
        builder.Property(brand => brand.WebsiteUrl)
            .HasMaxLength(400)
            .IsRequired();
        
        builder.HasMany(brand => brand.Products)
            .WithOne(product => product.Brand)
            .HasForeignKey(product => product.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}