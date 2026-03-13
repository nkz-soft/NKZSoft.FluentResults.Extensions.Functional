namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps an awaited successful result with an asynchronous task function and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The type of the mapped value.</typeparam>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task producing the mapped successful result, the original failure, or a failed result created from a thrown exception.</returns>
    public static async Task<Result<TValue>> MapTryAsync<TValue>(
        this Task<Result> resultTask,
        Func<Task<TValue>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Maps an awaited successful result with an asynchronous valuetask function and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The type of the mapped value.</typeparam>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task producing the mapped successful result, the original failure, or a failed result created from a thrown exception.</returns>
    public static async Task<Result<TValue>> MapTryAsync<TValue>(
        this Task<Result> resultTask,
        Func<ValueTask<TValue>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Maps an awaited successful result with an asynchronous task function and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The source value type.</typeparam>
    /// <typeparam name="TValueOut">The type of the mapped value.</typeparam>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task producing the mapped successful result, the original failure, or a failed result created from a thrown exception.</returns>
    public static async Task<Result<TValueOut>> MapTryAsync<TValue, TValueOut>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, Task<TValueOut>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Maps an awaited successful result with an asynchronous valuetask function and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The source value type.</typeparam>
    /// <typeparam name="TValueOut">The type of the mapped value.</typeparam>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task producing the mapped successful result, the original failure, or a failed result created from a thrown exception.</returns>
    public static async Task<Result<TValueOut>> MapTryAsync<TValue, TValueOut>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, ValueTask<TValueOut>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapTryAsync(func, errorHandler).ConfigureAwait(false);
    }
}
