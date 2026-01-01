namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously maps a Result using an asynchronous function.
    /// </summary>
    /// <typeparam name="TValue">The type of the value returned by the function.</typeparam>
    /// <param name="result">The Result to map.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <returns>A task containing the mapped Result.</returns>
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
    /// Asynchronously maps a Result using an asynchronous function.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the Result.</typeparam>
    /// <typeparam name="TValueOut">The type of the value returned by the function.</typeparam>
    /// <param name="result">The Result to map.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <returns>A task containing the mapped Result.</returns>
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
