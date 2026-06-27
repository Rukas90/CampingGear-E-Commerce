using TrailStore.Catalog.Application.Results;

namespace TrailStore.Catalog.Api.Endpoints.GetCategories;

public static class CategoryResponseMapping
{
    public static CategoryResponse[] ToResponses(this ICollection<CategoryResult> categories)
        => categories.Select(ToResponse).ToArray();

    public static CategoryResponse ToResponse(this CategoryResult category)
    {
        return new CategoryResponse
        {
            Name = category.Name,
            Description = category.Description,
            GroupSlug = category.GroupSlug,
            Slug = category.Slug,
            ImageUrl = category.ImageUrl
        };
    }
}