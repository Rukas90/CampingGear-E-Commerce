
using System.Diagnostics.CodeAnalysis;

namespace TrailStore.Shared.Common;

public class Result
{
    public bool     IsSuccess { get; }
    public Problem? Problem   { get; }

    protected Result(bool isSuccess, Problem? problem)
    {
        IsSuccess = isSuccess;
        Problem   = problem;
    }

    public static Result Success() 
        => new(isSuccess: true, problem: null);
    
    public static Result Failure(Problem problem)
        => new(isSuccess: false, problem);
}

public class Result<T>
{
    [MemberNotNullWhen(true, nameof(Value))]
    [MemberNotNullWhen(false, nameof(Problem))]
    
    public bool     IsSuccess { get; }
    public T?       Value     { get; }
    public Problem? Problem   { get; }
    
    protected Result(T value)
    {
        IsSuccess = true;
        Value     = value;
    }
    protected Result(Problem problem)
    {
        IsSuccess      = false;
        Problem = problem;
    }
    
    public static implicit operator Result<T>(T value) 
        => Success(value);
    
    public static implicit operator Result<T>(Problem problem)
        => Failure(problem);

    public static Result<T> Success(T value)
        => new(value);
    
    public static Result<T> Failure(Problem problem)
        => new(problem);

    public R Match<R>(Func<T, R> onSuccess, Func<Problem, R> onFailure)
    {
        if (IsSuccess)
        {
            return onSuccess(Value!);
        }
        return onFailure(Problem!);
    }
}