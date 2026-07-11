using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Identity.Domain.RefreshTokens;

namespace TrailStore.Identity.Infrastructure.Database.Configurations;

public sealed class RefreshFamilyConfiguration : IEntityTypeConfiguration<RefreshFamily>
{
    public void Configure(EntityTypeBuilder<RefreshFamily> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.UserId)
            .IsRequired();
        
        builder.HasMany(family => family.RefreshTokens)
            .WithOne()
            .HasForeignKey(token => token.FamilyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}