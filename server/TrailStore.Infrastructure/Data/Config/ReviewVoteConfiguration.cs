using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class ReviewVoteConfiguration : IEntityTypeConfiguration<ReviewVote>
{
    public void Configure(EntityTypeBuilder<ReviewVote> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.IsLike)
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .IsRequired();
        
        builder.HasOne(vote => vote.Review)
            .WithMany(review => review.Votes)
            .HasForeignKey(review => review.ReviewId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}