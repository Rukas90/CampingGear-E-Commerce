using FastEndpoints;

namespace TrailStore.Api.Categories.Dto;

public class TopCategoriesRequest
{
    [QueryParam]
    public int Count { get; set; }
}