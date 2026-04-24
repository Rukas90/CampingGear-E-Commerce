using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class ProductImageUrlConfiguration : IEntityTypeConfiguration<ProductImageUrl>
{
    public void Configure(EntityTypeBuilder<ProductImageUrl> builder)
    {
        builder.HasKey(url => url.Id);
        
        builder.Property(url => url.Url)
            .HasMaxLength(400)
            .IsRequired();
        
        builder.HasIndex(url => new { url.ProductImageId, url.SortOrder })
            .IsUnique();
    }
}