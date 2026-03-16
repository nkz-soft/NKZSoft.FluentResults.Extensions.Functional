namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapIfTryAsync(this ValueTask<Result> resultTask, bool condition, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIfTry(condition, action, errorHandler);
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIfTry(condition, action, errorHandler);
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Action<TValue> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIfTry(condition, action, errorHandler);
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapIfTryAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIfTry(predicate, action, errorHandler);
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, bool> predicate, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIfTry(predicate, action, errorHandler);
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, bool> predicate, Action<TValue> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIfTry(predicate, action, errorHandler);
    }
}
