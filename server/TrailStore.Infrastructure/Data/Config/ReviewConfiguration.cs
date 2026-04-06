using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(review => review.Id);
        
        builder.Property(review => review.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql("getdate()");

        builder.Property(review => review.Rating)
               .IsRequired();

        builder.Property(review => review.Headline)
               .IsRequired()
               .HasMaxLength(100);
        
        builder.Property(review => review.Text)
               .IsRequired()
               .HasMaxLength(1000);
        
        builder.HasOne(review => review.Customer)
               .WithMany(user => user.Reviews)
               .HasForeignKey(review => review.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(review => review.Product)
               .WithMany(product => product.Reviews)
               .HasForeignKey(review => review.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}