namespace TrailStore.Shared.Validation;

public readonly struct ValidationScope()
{
    public string? Prefix { get; init; } = null;
    
    public static ValidationScope Default => new();

    public string GetScopedField(string fieldName)
    {
        if (string.IsNullOrEmpty(Prefix))
        {
            return fieldName;
        }

        return $"{Prefix}.{fieldName}";
    }
}