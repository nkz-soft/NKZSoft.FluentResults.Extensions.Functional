namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result> TapIfTryAsync(this Task<Result> resultTask, bool condition, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIfTry(condition, action, errorHandler);
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result<TValue>> TapIfTryAsync<TValue>(this Task<Result<TValue>> resultTask, bool condition, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIfTry(condition, action, errorHandler);
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result<TValue>> TapIfTryAsync<TValue>(this Task<Result<TValue>> resultTask, bool condition, Action<TValue> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIfTry(condition, action, errorHandler);
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result> TapIfTryAsync(this Task<Result> resultTask, Func<bool> predicate, Action action, Func<Exception, string>? errorHandler = null)
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
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result<TValue>> TapIfTryAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> predicate, Action action, Func<Exception, string>? errorHandler = null)
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
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result<TValue>> TapIfTryAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> predicate, Action<TValue> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIfTry(predicate, action, errorHandler);
    }
}
