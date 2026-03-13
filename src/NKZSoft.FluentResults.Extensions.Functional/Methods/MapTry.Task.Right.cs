namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps a successful result with an asynchronous task function and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The type of the mapped value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task producing the mapped successful result, the original failure, or a failed result created from a thrown exception.</returns>
    public static Task<Result<TValue>> MapTryAsync<TValue>(
        this Result result,
        Func<Task<TValue>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed
            ? Task.FromResult(Result.Fail<TValue>(result.Errors))
            : TryAsync(func, errorHandler);
    }

    /// <summary>
    /// Maps a successful result with an asynchronous task function and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The source value type.</typeparam>
    /// <typeparam name="TValueOut">The type of the mapped value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task producing the mapped successful result, the original failure, or a failed result created from a thrown exception.</returns>
    public static Task<Result<TValueOut>> MapTryAsync<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Task<TValueOut>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed
            ? Task.FromResult(Result.Fail<TValueOut>(result.Errors))
            : TryAsync(() => func(result.Value), errorHandler);
    }
}
