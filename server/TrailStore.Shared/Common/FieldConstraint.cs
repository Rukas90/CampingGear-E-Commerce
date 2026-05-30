namespace TrailStore.Shared.Common;

public record FieldConstraint(int MinLength, int MaxLength, bool IsRequired);