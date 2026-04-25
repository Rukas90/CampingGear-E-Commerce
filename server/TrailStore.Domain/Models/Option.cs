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
    public PreviewType?             PreviewType   { get; init; }
    public string?                  PreviewValue  { get; init; }
    
    public OptionGroup      OptionGroup { get; private set; } = null!;
    public ICollection<Sku> Skus        { get; private set; } = [];

    public static Option Create(
        Id<Option>      id, 
        Id<OptionGroup> optionGroupId, 
        string          name, 
        string          slug, 
        PreviewType?    previewType = null, 
        string?         previewValue = null)
        => new()
        {
            Id            = id,
            OptionGroupId = optionGroupId,
            Name          = name,
            Slug          = slug,
            PreviewValue  = previewValue,
            PreviewType   = previewType
        };
    
    public static Option Create(
        Id<OptionGroup> optionGroupId, 
        string          name,
        string          slug, 
        PreviewType?    previewType = null, 
        string?         previewValue = null)
        => new()
        {
            Id            = Id<Option>.Part(optionGroupId).Part(slug).Build(),
            OptionGroupId = optionGroupId,
            Name          = name,
            Slug          = slug,
            PreviewValue  = previewValue,
            PreviewType   = previewType
        };
}