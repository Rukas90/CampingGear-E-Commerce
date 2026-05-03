using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Data.Config;

public class CategoryGroupConfiguration : IEntityTypeConfiguration<CategoryGroup>
{
    public void Configure(EntityTypeBuilder<CategoryGroup> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(c => c.Slug)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasIndex(c => c.Slug)
            .IsUnique();
        
        builder.Property(group => group.SortOrder)
            .IsRequired();
        
        builder.HasMany(group => group.Categories)
            .WithOne(category => category.Group)
            .HasForeignKey(category => category.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}