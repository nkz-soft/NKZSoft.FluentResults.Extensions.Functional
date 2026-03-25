namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    private static string DefaultErrorMessageHandler(Exception exception) => exception.Message;
    private static Error DefaultErrorHandler(Exception exception) => new(exception.Message);
    private static IEnumerable<IError> DefaultErrorsHandler(Exception exception) => [DefaultErrorHandler(exception)];

    /// <summary>
    /// Executes the supplied action and converts thrown exceptions into a failed result.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to a failure message. When omitted, the exception message is used.</param>
    /// <returns>A successful result when the action completes without throwing; otherwise a failed result created from the thrown exception.</returns>
    public static Result Try(Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);
        errorHandler ??= DefaultErrorMessageHandler;

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
    /// Executes the supplied action and converts thrown exceptions into a failed result.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to a single <see cref="IError"/> instance.</param>
    /// <returns>A successful result when the action completes without throwing; otherwise a failed result created from the thrown exception.</returns>
    public static Result Try(Action action, Func<Exception, IError> errorHandler)
        => Try(action, exception => new[] { (errorHandler ?? DefaultErrorHandler)(exception) });

    /// <summary>
    /// Executes the supplied action and converts thrown exceptions into a failed result.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to one or more <see cref="IError"/> instances.</param>
    /// <returns>A successful result when the action completes without throwing; otherwise a failed result created from the thrown exception.</returns>
    public static Result Try(Action action, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        errorHandler ??= DefaultErrorsHandler;

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
    /// Executes the supplied function and converts thrown exceptions into a failed result.
    /// </summary>
    /// <typeparam name="TValue">The type produced by the function on success.</typeparam>
    /// <param name="func">The function to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to a failure message. When omitted, the exception message is used.</param>
    /// <returns>A successful result containing the function value when execution succeeds; otherwise a failed result created from the thrown exception.</returns>
    public static Result<TValue> Try<TValue>(Func<TValue> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);
        errorHandler ??= DefaultErrorMessageHandler;

        try
        {
            return Result.Ok(func());
        }
        catch (Exception exception)
        {
            return Result.Fail<TValue>(errorHandler(exception));
        }
    }

    /// <summary>
    /// Executes the supplied function and converts thrown exceptions into a failed result.
    /// </summary>
    /// <typeparam name="TValue">The type produced by the function on success.</typeparam>
    /// <param name="func">The function to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to a single <see cref="IError"/> instance.</param>
    /// <returns>A successful result containing the function value when execution succeeds; otherwise a failed result created from the thrown exception.</returns>
    public static Result<TValue> Try<TValue>(Func<TValue> func, Func<Exception, IError> errorHandler)
        => Try(func, exception => new[] { (errorHandler ?? DefaultErrorHandler)(exception) });

    /// <summary>
    /// Executes the supplied function and converts thrown exceptions into a failed result.
    /// </summary>
    /// <typeparam name="TValue">The type produced by the function on success.</typeparam>
    /// <param name="func">The function to execute.</param>
    /// <param name="errorHandler">Maps a thrown exception to one or more <see cref="IError"/> instances.</param>
    /// <returns>A successful result containing the function value when execution succeeds; otherwise a failed result created from the thrown exception.</returns>
    public static Result<TValue> Try<TValue>(Func<TValue> func, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        errorHandler ??= DefaultErrorsHandler;

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
