namespace TrailStore.Shared.Validation;

public record ValidationState
{
    public List<ValidationFailure> Failures
    {
        get => field ??= [];
    } = null;

    private bool isValid = true;
    public bool IsValid => isValid;

    private ValidationState()
    {
        isValid = true;
    }

    private ValidationState(List<ValidationFailure> failures)
    {
        isValid = false;
        Failures = failures;
    }
    
    public ValidationState FailedWith(ValidationFailure failure)
    {
        Failures.Add(failure);
        isValid = false;

        return this;
    }

    public static ValidationState Ok()
        => new();
    
    public static ValidationState Fail(List<ValidationFailure> failures)
        => new(failures);
    
    public static implicit operator ValidationState(ValidationFailure failure) 
        => Fail([failure]);
}