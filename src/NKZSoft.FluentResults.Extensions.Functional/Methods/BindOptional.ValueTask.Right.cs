namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static ValueTask<Result<TValueOut?>> BindOptionalAsync<TValue, TValueOut>(
        this Result<TValue?> result,
        Func<TValue, ValueTask<Result<TValueOut?>>> func)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return ValueTask.FromResult(Result.Fail<TValueOut?>(result.Errors));
        }

        return result.Value is null
            ? ValueTask.FromResult(Result.Ok<TValueOut?>(default))
            : func(result.Value);
    }

    public static ValueTask<Result<TValueOut?>> BindOptionalAsync<TValue, TValueOut>(
        this Result<TValue?> result,
        Func<TValue, ValueTask<Result<TValueOut?>>> func)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return ValueTask.FromResult(Result.Fail<TValueOut?>(result.Errors));
        }

        return result.Value.HasValue
            ? func(result.Value.Value)
            : ValueTask.FromResult(Result.Ok<TValueOut?>(default));
    }
}
