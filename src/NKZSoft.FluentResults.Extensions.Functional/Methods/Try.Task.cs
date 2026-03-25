namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes the supplied asynchronous action and converts thrown exceptions into a failed result.
    /// </summary>
    /// <param name="action">The asynchronous action to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to a failure message. When omitted, the exception message is used.</param>
    /// <returns>A successful result when the action completes without throwing; otherwise a failed result created from the thrown exception.</returns>
    public static async Task<Result> TryAsync(Func<Task> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);
        errorHandler ??= DefaultErrorMessageHandler;

        try
        {
            await action().ConfigureAwait(false);

            return Result.Ok();
        }
        catch (Exception exception)
        {
            return Result.Fail(errorHandler(exception));
        }
    }

    /// <summary>
    /// Executes the supplied asynchronous action and converts thrown exceptions into a failed result.
    /// </summary>
    /// <param name="action">The asynchronous action to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to a single <see cref="IError"/> instance.</param>
    /// <returns>A successful result when the action completes without throwing; otherwise a failed result created from the thrown exception.</returns>
    public static Task<Result> TryAsync(Func<Task> action, Func<Exception, IError> errorHandler)
        => TryAsync(action, exception => new[] { (errorHandler ?? DefaultErrorHandler)(exception) });

    /// <summary>
    /// Executes the supplied asynchronous action and converts thrown exceptions into a failed result.
    /// </summary>
    /// <param name="action">The asynchronous action to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to one or more <see cref="IError"/> instances.</param>
    /// <returns>A successful result when the action completes without throwing; otherwise a failed result created from the thrown exception.</returns>
    public static async Task<Result> TryAsync(Func<Task> action, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        errorHandler ??= DefaultErrorsHandler;

        try
        {
            await action().ConfigureAwait(false);

            return Result.Ok();
        }
        catch (Exception exception)
        {
            return Result.Fail(errorHandler(exception));
        }
    }

    /// <summary>
    /// Executes the supplied asynchronous function and converts thrown exceptions into a failed result.
    /// </summary>
    /// <typeparam name="TValue">The type produced by the function on success.</typeparam>
    /// <param name="func">The asynchronous function to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to a failure message. When omitted, the exception message is used.</param>
    /// <returns>A successful result containing the function value when execution succeeds; otherwise a failed result created from the thrown exception.</returns>
    public static async Task<Result<TValue>> TryAsync<TValue>(Func<Task<TValue>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);
        errorHandler ??= DefaultErrorMessageHandler;

        try
        {
            var value = await func().ConfigureAwait(false);

            return Result.Ok(value);
        }
        catch (Exception exception)
        {
            return Result.Fail<TValue>(errorHandler(exception));
        }
    }

    /// <summary>
    /// Executes the supplied asynchronous function and converts thrown exceptions into a failed result.
    /// </summary>
    /// <typeparam name="TValue">The type produced by the function on success.</typeparam>
    /// <param name="func">The asynchronous function to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to a single <see cref="IError"/> instance.</param>
    /// <returns>A successful result containing the function value when execution succeeds; otherwise a failed result created from the thrown exception.</returns>
    public static Task<Result<TValue>> TryAsync<TValue>(Func<Task<TValue>> func, Func<Exception, IError> errorHandler)
        => TryAsync(func, exception => new[] { (errorHandler ?? DefaultErrorHandler)(exception) });

    /// <summary>
    /// Executes the supplied asynchronous function and converts thrown exceptions into a failed result.
    /// </summary>
    /// <typeparam name="TValue">The type produced by the function on success.</typeparam>
    /// <param name="func">The asynchronous function to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to one or more <see cref="IError"/> instances.</param>
    /// <returns>A successful result containing the function value when execution succeeds; otherwise a failed result created from the thrown exception.</returns>
    public static async Task<Result<TValue>> TryAsync<TValue>(Func<Task<TValue>> func, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        errorHandler ??= DefaultErrorsHandler;

        try
        {
            var value = await func().ConfigureAwait(false);

            return Result.Ok(value);
        }
        catch (Exception exception)
        {
            return Result.Fail<TValue>(errorHandler(exception));
        }
    }
}
