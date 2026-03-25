namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a task function when the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result> TapTryAsync(this Task<Result> resultTask, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a valuetask function when the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result> TapTryAsync(this Task<Result> resultTask, Func<ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? attempt : result;
    }

    /// <summary>
    /// Executes a task function when the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result<TValue>> TapTryAsync<TValue>(this Task<Result<TValue>> resultTask, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a valuetask function when the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result<TValue>> TapTryAsync<TValue>(this Task<Result<TValue>> resultTask, Func<ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }

    /// <summary>
    /// Executes a task function when the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result<TValue>> TapTryAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a valuetask function when the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result<TValue>> TapTryAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = await TryAsync(() => func(result.Value), errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }
}
