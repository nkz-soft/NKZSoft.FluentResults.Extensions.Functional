namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Binds an optional result value only when a value is present.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <typeparam name="TValueOut">The type of the bound result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns a successful optional result when the source has no value, the original errors when the source is failed, or the bound result when a value is present.</returns>
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

    /// <summary>
    /// Binds an optional result value only when a value is present.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <typeparam name="TValueOut">The type of the bound result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns a successful optional result when the source has no value, the original errors when the source is failed, or the bound result when a value is present.</returns>
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
