using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Identity.Domain.RefreshTokens;

namespace TrailStore.Identity.Infrastructure.Database.Configurations;

public sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FamilyId)
            .IsRequired();
        
        builder.Property(c => c.TokenHash)
            .IsRequired();
        
        builder.Property(c => c.LookupHash)
            .IsRequired();
    }
}