using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Basket.Domain.Carts;

namespace TrailStore.Basket.Infrastructure.Database.Configurations;

public sealed class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.UserId)
            .IsRequired(false);
        
        builder.Property(i => i.CreatedAt)
            .HasDefaultValueSql("NOW()")
            .IsRequired();

        builder.HasMany(cart => cart.Items)
            .WithOne(item => item.Cart)
            .HasForeignKey(item => item.CartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}