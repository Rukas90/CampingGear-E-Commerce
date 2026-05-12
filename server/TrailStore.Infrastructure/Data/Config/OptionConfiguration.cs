using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class OptionConfiguration : IEntityTypeConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.HasKey(option => option.Id);

        builder.Property(option => option.OptionGroupId)
            .IsRequired();

        builder.Property(option => option.Name)
            .HasMaxLength(125)
            .IsRequired();

        builder.Property(option => option.Slug)
            .HasMaxLength(125)
            .IsRequired();

        builder.Property(o => o.PreviewType)
            .HasConversion<string>();

        builder.Property(option => option.PreviewValue)
            .HasMaxLength(400);

        builder.HasIndex(option => new { option.OptionGroupId, option.Slug })
            .IsUnique();

        builder.HasOne(option => option.OptionGroup)
            .WithMany(group => group.Options)
            .HasForeignKey(option => option.OptionGroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}