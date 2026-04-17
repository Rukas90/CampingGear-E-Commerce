
namespace TrailStore.Shared.Common;

public class Result
{
    public bool   IsSuccess { get; }
    public Error? Error     { get; }

    protected Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error     = error;
    }

    public static Result Success() 
        => new(isSuccess: true, error: null);
    
    public static Result Failure(Error error)
        => new(isSuccess: false, error);
}

public class Result<T>
{
    public bool   IsSuccess { get; }
    public T?     Value     { get; }
    public Error? Error     { get; }
    
    protected Result(T value)
    {
        IsSuccess = true;
        Value     = value;
    }
    protected Result(Error error)
    {
        IsSuccess = false;
        Error     = error;
    }
    
    public static implicit operator Result<T>(T value) 
        => Success(value);
    
    public static implicit operator Result<T>(Error error)
        => Failure(error);

    public static Result<T> Success(T value)
        => new(value);
    
    public static Result<T> Failure(Error error)
        => new(error);

    public R Match<R>(Func<T, R> onSuccess, Func<Error, R> onFailure)
    {
        if (IsSuccess)
        {
            return onSuccess(Value!);
        }
        return onFailure(Error!);
    }
}