namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Attempts to execute the supplied asynchronous action and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="action">The asynchronous action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A successful Result when no exception is thrown; otherwise a failed Result.</returns>
    public static async ValueTask<Result> TryAsync(Func<ValueTask> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);
        errorHandler ??= static exception => exception.Message;

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
    public static async ValueTask<Result<TValue>> TryAsync<TValue>(Func<ValueTask<TValue>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);
        errorHandler ??= static exception => exception.Message;

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
