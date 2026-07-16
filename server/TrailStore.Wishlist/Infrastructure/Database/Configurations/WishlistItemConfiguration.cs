using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Wishlist.Domain;

namespace TrailStore.Wishlist.Infrastructure.Database.Configurations;

public class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItem>
{
    public void Configure(EntityTypeBuilder<WishlistItem> builder)
    {
        builder.HasKey(item => item.Id);

        builder.Property(item => item.SkuId)
            .IsRequired();
    }
}