namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Attempts to execute the supplied action and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A successful Result when no exception is thrown; otherwise a failed Result.</returns>
    public static Result Try(Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);
        errorHandler ??= static exception => exception.Message;

        try
        {
            action();

            return Result.Ok();
        }
        catch (Exception exception)
        {
            return Result.Fail(errorHandler(exception));
        }
    }

    /// <summary>
    /// Attempts to execute the supplied function and returns a Result indicating success or failure.
    /// </summary>
    /// <typeparam name="TValue">The return type of the function.</typeparam>
    /// <param name="func">The function to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A successful Result containing the function value when no exception is thrown; otherwise a failed Result.</returns>
    public static Result<TValue> Try<TValue>(Func<TValue> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);
        errorHandler ??= static exception => exception.Message;

        try
        {
            return Result.Ok(func());
        }
        catch (Exception exception)
        {
            return Result.Fail<TValue>(errorHandler(exception));
        }
    }
}
