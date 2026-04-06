using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class OptionGroupConfiguration : IEntityTypeConfiguration<OptionGroup>
{
    public void Configure(EntityTypeBuilder<OptionGroup> builder)
    {
        builder.HasKey(group => group.Id);
        
        builder.Property(group => group.Name)
               .IsRequired()
               .HasMaxLength(200);
        
        builder.HasIndex(group => group.Name)
               .IsUnique();
        
        builder.HasMany(group => group.Options)
            .WithOne(option => option.OptionGroup)
            .HasForeignKey(option => option.OptionGroupId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}