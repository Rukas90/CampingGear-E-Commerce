using TrailStore.Catalog.Domain.Categories;

namespace TrailStore.Catalog.Api.Endpoints.GetCategories;

public static class CategoryResponseMapping
{
    public static CategoryResponse[] ToResponses(this ICollection<Category> categories)
        => categories.Select(ToResponse).ToArray();

    public static CategoryResponse ToResponse(this Category category)
    {
        return new CategoryResponse
        {
            Name = category.Name,
            Description = category.Description,
            GroupSlug = category.Group.Slug,
            Slug = category.Slug,
            ImageUrl = category.ImageUrl
        };
    }
}