using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);
              
        builder.Property(r => r.Rating)
            .IsRequired();
              
        builder.Property(r => r.Headline)
            .HasMaxLength(200)
            .IsRequired();
              
        builder.Property(r => r.Text)
            .HasMaxLength(2000)
            .IsRequired();
              
        builder.Property(r => r.CreatedAt)
            .IsRequired();
              
        builder.HasOne(r => r.Customer)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
              
        builder.HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}