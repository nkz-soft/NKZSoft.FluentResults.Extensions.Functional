namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes the action when the result is successful and converts thrown exceptions into failed results.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="action">Action to execute when the source result is successful.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original failed result, or the outcome of executing the action via <see cref="Try(Action,Func{Exception,string}?)"/>.</returns>
    public static Result OnSuccessTry(this Result result, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        return result.IsFailed
            ? result
            : Try(action, errorHandler);
    }
    /// <summary>
    /// Executes the action when the result is successful and converts thrown exceptions into failed results using a rich error mapper.
    /// </summary>
    public static Result OnSuccessTry(this Result result, Action action, Func<Exception, IError> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        return result.IsFailed
            ? result
            : Try(action, errorHandler);
    }
    /// <summary>
    /// Executes the action when the result is successful and converts thrown exceptions into failed results using a rich multi-error mapper.
    /// </summary>
    public static Result OnSuccessTry(this Result result, Action action, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        return result.IsFailed
            ? result
            : Try(action, errorHandler);
    }

    /// <summary>
    /// Executes the action when the result is successful and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">Type of the source result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="action">Action to execute with the source value when the source result is successful.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original failed result converted to <see cref="Result"/>, or the outcome of executing the action via <see cref="Try(Action,Func{Exception,string}?)"/>.</returns>
    public static Result OnSuccessTry<TValue>(this Result<TValue> result, Action<TValue> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        return result.IsFailed
            ? result.ToResult()
            : Try(() => action(result.Value), errorHandler);
    }
    /// <summary>
    /// Executes the action when the result is successful and converts thrown exceptions into failed results using a rich error mapper.
    /// </summary>
    public static Result OnSuccessTry<TValue>(this Result<TValue> result, Action<TValue> action, Func<Exception, IError> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        return result.IsFailed
            ? result.ToResult()
            : Try(() => action(result.Value), errorHandler);
    }
    /// <summary>
    /// Executes the action when the result is successful and converts thrown exceptions into failed results using a rich multi-error mapper.
    /// </summary>
    public static Result OnSuccessTry<TValue>(this Result<TValue> result, Action<TValue> action, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        return result.IsFailed
            ? result.ToResult()
            : Try(() => action(result.Value), errorHandler);
    }
}
