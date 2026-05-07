using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public enum PreviewType
{
    Color,
    Image
}
public class Option : IModel<Option>
{
    public required Id<Option>      Id            { get; init; }
    public required Id<OptionGroup> OptionGroupId { get; init; }
    public required string          Name          { get; init; }
    public required string          Slug          { get; init; }
    public required int             SortOrder     { get; init; }
    public PreviewType?             PreviewType   { get; init; }
    public string?                  PreviewValue  { get; init; }
    
    public OptionGroup      OptionGroup { get; private set; } = null!;
    public ICollection<Sku> Skus        { get; private set; } = [];
    
    public static Option Create(
        Id<OptionGroup> optionGroupId, 
        string          name,
        string          slug, 
        int             sortOrder = 0,
        PreviewType?    previewType = null, 
        string?         previewValue = null)
        => new()
        {
            Id            = Id<Option>.Part(optionGroupId).Part(slug).Build(),
            OptionGroupId = optionGroupId,
            Name          = name,
            Slug          = slug,
            SortOrder     = sortOrder,
            PreviewValue  = previewValue,
            PreviewType   = previewType
        };
}