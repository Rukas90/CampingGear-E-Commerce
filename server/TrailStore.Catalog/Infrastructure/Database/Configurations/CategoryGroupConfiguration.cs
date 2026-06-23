using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Catalog.Domain.Categories;

namespace TrailStore.Catalog.Infrastructure.Database.Configurations;

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
    }
}