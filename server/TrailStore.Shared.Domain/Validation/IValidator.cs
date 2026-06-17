namespace TrailStore.Shared.Domain.Validation;

public interface IValidator<in TData>
{
    static abstract ValidationState Validate(TData data, ValidationState? state = null);
}