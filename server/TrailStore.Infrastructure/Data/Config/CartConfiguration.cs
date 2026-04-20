using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(cart => cart.Id);
        
        builder.HasOne(c => c.Customer)
            .WithOne(c => c.Cart)
            .HasForeignKey<Cart>(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}