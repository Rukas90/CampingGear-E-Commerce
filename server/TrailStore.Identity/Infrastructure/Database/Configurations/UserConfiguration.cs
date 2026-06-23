using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Identity.Domain.Users;

namespace TrailStore.Identity.Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName)
            .HasMaxLength(100);

        builder.Property(c => c.LastName)
            .HasMaxLength(100);

        builder.Property(c => c.Email)
            .HasMaxLength(254)
            .IsRequired();

        builder.HasIndex(c => c.Email)
            .IsUnique();

        builder.Property(c => c.PasswordHash)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(c => c.Privileges)
            .HasConversion<string>()
            .IsRequired();
    }
}