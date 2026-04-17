using TrailStore.Domain.Models;

namespace TrailStore.Api.Products.Dto;

public class OptionDto
{
    public  Guid        Id           { get; init; }
    public string       Name         { get; init; }
    public string       Slug         { get; init; }
    public PreviewType? PreviewType  { get; init; }
    public string?      PreviewValue { get; init; }
}