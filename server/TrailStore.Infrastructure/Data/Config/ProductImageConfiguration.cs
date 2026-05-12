using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(image => image.Id);

        builder.HasOne(image => image.Product)
            .WithMany(product => product.Images)
            .HasForeignKey(image => image.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Option>()
            .WithMany()
            .HasForeignKey(image => image.OptionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(image => new { image.ProductId, image.OptionId })
            .IsUnique();

        builder.HasMany(image => image.Urls)
            .WithOne()
            .HasForeignKey(url => url.ProductImageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}