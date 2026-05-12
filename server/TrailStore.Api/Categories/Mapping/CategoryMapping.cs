using TrailStore.Api.Categories.Dto;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Api.Categories.Mapping;

public static class CategoryMapping
{
    public static IEnumerable<CategoryDto> ToDto(this ICollection<Category> categories)
    {
        return categories.Select(ToDto);
    }

    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto
        {
            Name = category.Name,
            Description = category.Description,
            GroupSlug = category.Group.Slug,
            Slug = category.Slug,
            ImageUrl = category.ImageUrl
        };
    }

    public static IEnumerable<CategoryGroupDto> ToDto(this ICollection<CategoryGroup> groups)
    {
        return groups.Select(ToDto);
    }

    public static CategoryGroupDto ToDto(this CategoryGroup category)
    {
        return new CategoryGroupDto
        {
            Name = category.Name,
            Slug = category.Slug,
            SortOrder = category.SortOrder
        };
    }
}