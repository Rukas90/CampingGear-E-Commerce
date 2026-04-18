namespace TrailStore.Api.Categories.Dto;

public class CategoryDto
{
    public          Guid    Id          { get; init; }
    public required string  Name        { get; init; }
    public          string? Description { get; init; }
    public required string  Slug        { get; init; }
    public          string? ImageUrl    { get; init; }
    
}