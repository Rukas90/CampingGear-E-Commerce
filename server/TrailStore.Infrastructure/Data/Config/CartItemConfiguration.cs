using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(i => i.Id);
        
        builder.Property(i => i.Quantity)
            .IsRequired();
        
        builder.Property(i => i.AddedAt)
            .HasDefaultValueSql("NOW()")
            .IsRequired();
        
        builder.HasOne(i => i.Cart)
            .WithMany(c => c.Items)
            .HasForeignKey(i => i.CartId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(i => i.Sku)
            .WithMany()
            .HasForeignKey(i => i.SkuId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}