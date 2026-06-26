using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Basket.Domain.Carts;

namespace TrailStore.Basket.Infrastructure.Database.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Quantity)
            .IsRequired();

        builder.Property(i => i.CreatedAt)
            .HasDefaultValueSql("NOW()")
            .IsRequired();

        builder.HasOne(i => i.ShoppingSession)
            .WithMany(c => c.CartItems)
            .HasForeignKey(i => i.SessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}