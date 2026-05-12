using System.Diagnostics.CodeAnalysis;

namespace TrailStore.Shared.Common;

public class Result
{
    protected Result(bool isSuccess, Problem? problem)
    {
        IsSuccess = isSuccess;
        Problem = problem;
    }

    public bool IsSuccess { get; }
    public Problem? Problem { get; }

    public static Result Success()
    {
        return new Result(true, null);
    }

    public static Result Failure(Problem problem)
    {
        return new Result(false, problem);
    }
}

public class Result<T>
{
    protected Result(T value)
    {
        IsSuccess = true;
        Value = value;
    }

    protected Result(Problem problem)
    {
        IsSuccess = false;
        Problem = problem;
    }

    [MemberNotNullWhen(true, nameof(Value))]
    [MemberNotNullWhen(false, nameof(Problem))]

    public bool IsSuccess { get; }

    public T? Value { get; }
    public Problem? Problem { get; }

    public static implicit operator Result<T>(T value)
    {
        return Success(value);
    }

    public static implicit operator Result<T>(Problem problem)
    {
        return Failure(problem);
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }

    public static Result<T> Failure(Problem problem)
    {
        return new Result<T>(problem);
    }

    public R Match<R>(Func<T, R> onSuccess, Func<Problem, R> onFailure)
    {
        if (IsSuccess) return onSuccess(Value!);
        return onFailure(Problem!);
    }
}