using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Catalog.Domain.Reviews.Models;

namespace TrailStore.Catalog.Infrastructure.Database.Configurations;

public class ReviewVoteConfiguration : IEntityTypeConfiguration<ReviewVote>
{
    public void Configure(EntityTypeBuilder<ReviewVote> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.IsLike)
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .IsRequired();
    }
}