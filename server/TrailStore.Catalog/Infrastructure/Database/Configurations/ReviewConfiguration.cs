using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Catalog.Domain.Reviews;
using TrailStore.Catalog.Domain.Reviews.Models;

namespace TrailStore.Catalog.Infrastructure.Database.Configurations;

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
        
        builder.HasMany(review => review.Votes)
            .WithOne(vote => vote.Review)
            .HasForeignKey(vote => vote.ReviewId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}