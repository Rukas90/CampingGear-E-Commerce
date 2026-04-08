using System.ComponentModel.DataAnnotations;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class OptionGroup : IModel<OptionGroup>
{
    public required Id<OptionGroup> Id        { get; init; }
    [MaxLength(200)]
    public required string          Name      { get; init; }
    [MaxLength(200)]
    public required string          Slug      { get; init; }
    public          int             SortOrder { get; init; } = 0;
    
    public ICollection<Option> Options { get; private set; } = [];

    public static OptionGroup Create(Id<OptionGroup> id, string name, string slug, int sortOrder = 0)
        => new()
        {
            Id        = id,
            Name      = name,
            Slug      = slug,
            SortOrder = sortOrder
        };
    
    public static OptionGroup Create(string name, string slug, int sortOrder = 0)
        => new()
        {
            Id        = Id<OptionGroup>.Part(name).Build(),
            Name      = name,
            Slug      = slug,
            SortOrder = sortOrder
        };
}