namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Attempts to execute the supplied asynchronous action and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="action">The asynchronous action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A successful Result when no exception is thrown; otherwise a failed Result.</returns>
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
    /// Attempts to execute the supplied asynchronous action and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="action">The asynchronous action to execute.</param>
    /// <param name="errorHandler">Exception-to-error mapper. Defaults to exception message.</param>
    /// <returns>A successful Result when no exception is thrown; otherwise a failed Result.</returns>
    public static Task<Result> TryAsync(Func<Task> action, Func<Exception, IError> errorHandler)
        => TryAsync(action, exception => new[] { (errorHandler ?? DefaultErrorHandler)(exception) });

    /// <summary>
    /// Attempts to execute the supplied asynchronous action and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="action">The asynchronous action to execute.</param>
    /// <param name="errorHandler">Exception-to-errors mapper. Defaults to exception message.</param>
    /// <returns>A successful Result when no exception is thrown; otherwise a failed Result.</returns>
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
    /// Attempts to execute the supplied asynchronous function and returns a Result indicating success or failure.
    /// </summary>
    /// <typeparam name="TValue">The return type of the function.</typeparam>
    /// <param name="func">The asynchronous function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A successful Result containing the function value when no exception is thrown; otherwise a failed Result.</returns>
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
    /// Attempts to execute the supplied asynchronous function and returns a Result indicating success or failure.
    /// </summary>
    /// <typeparam name="TValue">The return type of the function.</typeparam>
    /// <param name="func">The asynchronous function to execute.</param>
    /// <param name="errorHandler">Exception-to-error mapper. Defaults to exception message.</param>
    /// <returns>A successful Result containing the function value when no exception is thrown; otherwise a failed Result.</returns>
    public static Task<Result<TValue>> TryAsync<TValue>(Func<Task<TValue>> func, Func<Exception, IError> errorHandler)
        => TryAsync(func, exception => new[] { (errorHandler ?? DefaultErrorHandler)(exception) });

    /// <summary>
    /// Attempts to execute the supplied asynchronous function and returns a Result indicating success or failure.
    /// </summary>
    /// <typeparam name="TValue">The return type of the function.</typeparam>
    /// <param name="func">The asynchronous function to execute.</param>
    /// <param name="errorHandler">Exception-to-errors mapper. Defaults to exception message.</param>
    /// <returns>A successful Result containing the function value when no exception is thrown; otherwise a failed Result.</returns>
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
