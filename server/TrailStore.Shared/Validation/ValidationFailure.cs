namespace TrailStore.Shared.Validation;

public readonly record struct ValidationFailure(string Field, string Message)
{
    public static ValidationFailure New(string field, string message)
        => new(field, message);
}