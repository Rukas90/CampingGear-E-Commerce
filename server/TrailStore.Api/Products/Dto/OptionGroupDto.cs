namespace TrailStore.Api.Products.Dto;

public class OptionGroupDto
{
    public Guid        GroupId   { get; init; }
    public string      Name      { get; init; }
    public string      Slug      { get; init; }
    public int         SortOrder { get; init; }
    public OptionDto[] Options   { get; init; } = [];
}