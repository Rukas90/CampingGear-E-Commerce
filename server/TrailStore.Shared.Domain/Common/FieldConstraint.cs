namespace TrailStore.Shared.Domain.Common;

public record FieldConstraint(int MinLength, int MaxLength, bool IsRequired);