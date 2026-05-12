using System.Linq.Expressions;
using TrailStore.Api.Categories.Dto;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Api.Categories.Mapping;

public class CategoryMappingSelectors
{
    public static Expression<Func<Category, CategoryDto>> ToDto { get; }
        = category => new CategoryDto
        {
            Name = category.Name,
            Description = category.Description,
            GroupSlug = category.Group.Slug,
            Slug = category.Slug,
            ImageUrl = category.ImageUrl
        };
}