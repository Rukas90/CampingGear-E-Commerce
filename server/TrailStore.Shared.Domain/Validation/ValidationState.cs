namespace TrailStore.Shared.Domain.Validation;

public record ValidationState
{
    public readonly record struct MappedFailure(string Field, string Message);
    
    public List<ValidationFailure> Failures
    {
        get => field ??= [];
    } = null;

    private bool isValid = true;
    public bool IsValid => isValid;

    private readonly ValidationScope scope;
    
    private ValidationState(ValidationScope scope)
    {
        this.scope = scope;
        isValid = true;
    }

    private ValidationState(List<ValidationFailure> failures, ValidationScope scope)
    {
        this.scope = scope;
        isValid = false;
        Failures = failures;
    }
    
    public ValidationState FailedWith(ValidationFailure failure)
    {
        Failures.Add(failure);
        isValid = false;

        return this;
    }

    public static ValidationState Ok(ValidationScope? scope = null)
        => new(scope ?? ValidationScope.Default);
    
    public static ValidationState Fail(List<ValidationFailure> failures, ValidationScope? scope = null)
        => new(failures, scope ?? ValidationScope.Default);
    
    public static ValidationState FailWith(ValidationFailure failure, ValidationScope? scope = null)
        => new([failure], scope ?? ValidationScope.Default);
    
    public static implicit operator ValidationState(ValidationFailure failure) 
        => Fail([failure]);

    public IEnumerable<TResult> Map<TResult>(Func<MappedFailure, TResult> selector)
    {
        return Failures
            .Select(failure => new MappedFailure(scope.GetScopedField(failure.Field), failure.Message))
            .Select(selector);
    }
}