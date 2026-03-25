namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Projects a successful result with an asynchronous mapping.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the mapped result.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The asynchronous projection to run when the source result is successful.</param>
    /// <returns>A task that returns the projected result, or a failed result that preserves the original errors.</returns>
    public static async Task<Result<TValue>> MapAsync<TValue>(this Result result, Func<Task<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<TValue>(result.Errors);
        }

        var value = await func().ConfigureAwait(false);
        return Result.Ok(value);
    }

    /// <summary>
    /// Projects a successful result value with an asynchronous mapping.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the source result.</typeparam>
    /// <typeparam name="TValueOut">The type carried by the mapped result.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The asynchronous projection to run with the successful source value.</param>
    /// <returns>A task that returns the projected result, or a failed result that preserves the original errors.</returns>
    public static async Task<Result<TValueOut>> MapAsync<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Task<TValueOut>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<TValueOut>(result.Errors);
        }

        var value = await func(result.Value).ConfigureAwait(false);
        return Result.Ok(value);
    }
}
