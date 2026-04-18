using TrailStore.Domain.Models;

namespace TrailStore.Api.Categories.Dto;

public class OptionDto
{
    public          Guid         Id           { get; init; }
    public required string       Name         { get; init; }
    public required string       Slug         { get; init; }
    public          PreviewType? PreviewType  { get; init; }
    public          string?      PreviewValue { get; init; }
}