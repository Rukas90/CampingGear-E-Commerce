namespace TrailStore.Shared.Validation;

public interface IValidator<in TData>
{
    static abstract ValidationState Validate(TData data, ValidationState? state = null);
}