namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a task function when the supplied condition is true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result> TapIfTryAsync(this Result result, bool condition, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed || !condition)
        {
            return result;
        }

        var attempt = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? attempt : result;
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result<TValue>> TapIfTryAsync<TValue>(this Result<TValue> result, bool condition, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed || !condition)
        {
            return result;
        }

        var attempt = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result<TValue>> TapIfTryAsync<TValue>(this Result<TValue> result, bool condition, Func<TValue, Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed || !condition)
        {
            return result;
        }

        var attempt = await TryAsync(() => func(result.Value), errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }

    /// <summary>
    /// Executes a task function when the supplied predicate evaluates to true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result> TapIfTryAsync(this Result result, Func<bool> predicate, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

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
    /// Executes a task function when the supplied predicate evaluates to true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result<TValue>> TapIfTryAsync<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

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
    /// Executes a task function when the supplied predicate evaluates to true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result<TValue>> TapIfTryAsync<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<TValue, Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return result;
        }

        var attempt = await TryAsync(() => predicate(result.Value) ? func(result.Value) : Task.CompletedTask, errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }
}
