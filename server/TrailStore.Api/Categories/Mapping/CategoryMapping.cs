using TrailStore.Api.Categories.Dto;
using TrailStore.Domain.Models;

namespace TrailStore.Api.Categories.Mapping;

public static class CategoryMapping
{
    public static IEnumerable<CategoryDto> ToDto(this ICollection<Category> categories)
        => categories.Select(ToDto);
    
    public static CategoryDto ToDto(this Category category)
        => new()
        {
            Name        = category.Name,
            Description = category.Description,
            Slug        = category.Slug,
            ImageUrl    = category.ImageUrl
        };
}