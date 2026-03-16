namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapIfTryAsync(this ValueTask<Result> resultTask, bool condition, Func<ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfTryAsync(condition, func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapIfTryAsync(this ValueTask<Result> resultTask, bool condition, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed || !condition)
        {
            return result;
        }

        var attempt = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? attempt : result;
    }

    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfTryAsync(condition, func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed || !condition)
        {
            return result;
        }

        var attempt = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }

    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<TValue, ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfTryAsync(condition, func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<TValue, Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed || !condition)
        {
            return result;
        }

        var attempt = await TryAsync(() => func(result.Value), errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }

    /// <summary>
    /// Executes a valuetask function when the supplied predicate evaluates to true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapIfTryAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Func<ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfTryAsync(predicate, func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied predicate evaluates to true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapIfTryAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = await TryAsync((Func<Task>)(async () =>
        {
            if (predicate())
            {
                await func().ConfigureAwait(false);
            }
        }), errorHandler).ConfigureAwait(false);

        return attempt.IsFailed ? attempt : result;
    }

    /// <summary>
    /// Executes a valuetask function when the supplied predicate evaluates to true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfTryAsync(predicate, func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied predicate evaluates to true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = await TryAsync((Func<Task>)(async () =>
        {
            if (predicate(result.Value))
            {
                await func().ConfigureAwait(false);
            }
        }), errorHandler).ConfigureAwait(false);

        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }

    /// <summary>
    /// Executes a valuetask function when the supplied predicate evaluates to true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<TValue, ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfTryAsync(predicate, func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied predicate evaluates to true and the awaited result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<TValue, Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = await TryAsync(() => predicate(result.Value) ? func(result.Value) : Task.CompletedTask, errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }
}
