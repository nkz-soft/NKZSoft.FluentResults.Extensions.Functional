namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action when the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result> TapTryAsync(this Task<Result> resultTask, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapTry(action, errorHandler);
    }

    /// <summary>
    /// Executes an action when the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result<TValue>> TapTryAsync<TValue>(this Task<Result<TValue>> resultTask, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapTry(action, errorHandler);
    }

    /// <summary>
    /// Executes an action when the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result<TValue>> TapTryAsync<TValue>(this Task<Result<TValue>> resultTask, Action<TValue> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapTry(action, errorHandler);
    }
}
