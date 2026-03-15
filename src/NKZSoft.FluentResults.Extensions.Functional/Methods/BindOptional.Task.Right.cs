namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static Task<Result<TValueOut?>> BindOptionalAsync<TValue, TValueOut>(
        this Result<TValue?> result,
        Func<TValue, Task<Result<TValueOut?>>> func)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Task.FromResult(Result.Fail<TValueOut?>(result.Errors));
        }

        return result.Value is null
            ? Task.FromResult(Result.Ok<TValueOut?>(default))
            : func(result.Value);
    }

    public static Task<Result<TValueOut?>> BindOptionalAsync<TValue, TValueOut>(
        this Result<TValue?> result,
        Func<TValue, Task<Result<TValueOut?>>> func)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Task.FromResult(Result.Fail<TValueOut?>(result.Errors));
        }

        return result.Value.HasValue
            ? func(result.Value.Value)
            : Task.FromResult(Result.Ok<TValueOut?>(default));
    }
}
