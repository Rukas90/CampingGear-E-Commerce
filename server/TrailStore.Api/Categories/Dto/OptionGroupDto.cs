namespace TrailStore.Api.Categories.Dto;

public class OptionGroupDto
{
    public          Guid        GroupId   { get; init; }
    public required string      Name      { get; init; }
    public required string      Slug      { get; init; }
    public          int         SortOrder { get; init; }
    public          OptionDto[] Options   { get; init; } = [];
}