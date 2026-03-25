namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a task function when the result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result> TapTryAsync(this Result result, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return result;
        }

        var attempt = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? attempt : result;
    }

    /// <summary>
    /// Executes a task function when the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result<TValue>> TapTryAsync<TValue>(this Result<TValue> result, Func<Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return result;
        }

        var attempt = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }

    /// <summary>
    /// Executes a task function when the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The task function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async Task<Result<TValue>> TapTryAsync<TValue>(this Result<TValue> result, Func<TValue, Task> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return result;
        }

        var attempt = await TryAsync(() => func(result.Value), errorHandler).ConfigureAwait(false);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }
}
