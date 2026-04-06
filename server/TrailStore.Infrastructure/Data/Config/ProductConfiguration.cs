using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);
        
        builder.Property(product => product.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(product => product.Description)
               .HasMaxLength(2000);
        
        builder.Property(product => product.Slug)
               .IsRequired()
               .HasMaxLength(200);
        
        builder.HasIndex(product => product.Slug)
               .IsUnique();

        builder.HasOne(product => product.Category)
               .WithMany(category => category.Products)
               .HasForeignKey(product => product.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(product => product.Brand)
               .WithMany(brand => brand.Products)
               .HasForeignKey(product => product.BrandId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}