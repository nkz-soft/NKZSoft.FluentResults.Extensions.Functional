namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps an awaited successful result with a synchronous function and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The type of the mapped value.</typeparam>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="func">The mapping function.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A ValueTask producing the mapped successful result, the original failure, or a failed result created from a thrown exception.</returns>
    public static async ValueTask<Result<TValue>> MapTryAsync<TValue>(
        this ValueTask<Result> resultTask,
        Func<TValue> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.InternalMapTry(func, errorHandler);
    }

    /// <summary>
    /// Maps an awaited successful result with a synchronous function and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The source value type.</typeparam>
    /// <typeparam name="TValueOut">The type of the mapped value.</typeparam>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="func">The mapping function.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A ValueTask producing the mapped successful result, the original failure, or a failed result created from a thrown exception.</returns>
    public static async ValueTask<Result<TValueOut>> MapTryAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, TValueOut> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.InternalMapTry(func, errorHandler);
    }
}
