using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Wishlist.Domain;

namespace TrailStore.Wishlist.Infrastructure.Database.Configurations;

public class CustomerWishlistConfiguration : IEntityTypeConfiguration<CustomerWishlist>
{
    public void Configure(EntityTypeBuilder<CustomerWishlist> builder)
    {
        builder.HasKey(wishlist => wishlist.Id);

        builder.Property(wishlist => wishlist.UserId)
            .IsRequired();
        
        builder.HasMany(wishlist => wishlist.Items)
            .WithOne()
            .HasForeignKey(item => item.WishlistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}