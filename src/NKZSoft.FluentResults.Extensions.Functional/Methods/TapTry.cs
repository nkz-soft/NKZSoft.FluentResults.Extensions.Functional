namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action when the result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original result, or a failed result when an exception occurs.</returns>
    public static Result TapTry(this Result result, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(action, errorHandler);
        return attempt.IsFailed ? attempt : result;
    }
    /// <summary>
    /// Executes an action when the result is successful, converting exceptions to failures using a rich error mapper.
    /// </summary>
    public static Result TapTry(this Result result, Action action, Func<Exception, IError> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(action, errorHandler);
        return attempt.IsFailed ? attempt : result;
    }
    /// <summary>
    /// Executes an action when the result is successful, converting exceptions to failures using a rich multi-error mapper.
    /// </summary>
    public static Result TapTry(this Result result, Action action, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(action, errorHandler);
        return attempt.IsFailed ? attempt : result;
    }

    /// <summary>
    /// Executes an action when the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original result, or a failed result when an exception occurs.</returns>
    public static Result<TValue> TapTry<TValue>(this Result<TValue> result, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(action, errorHandler);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }
    /// <summary>
    /// Executes an action when the result is successful, converting exceptions to failures using a rich error mapper.
    /// </summary>
    public static Result<TValue> TapTry<TValue>(this Result<TValue> result, Action action, Func<Exception, IError> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(action, errorHandler);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }
    /// <summary>
    /// Executes an action when the result is successful, converting exceptions to failures using a rich multi-error mapper.
    /// </summary>
    public static Result<TValue> TapTry<TValue>(this Result<TValue> result, Action action, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(action, errorHandler);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }

    /// <summary>
    /// Executes an action when the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original result, or a failed result when an exception occurs.</returns>
    public static Result<TValue> TapTry<TValue>(this Result<TValue> result, Action<TValue> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(() => action(result.Value), errorHandler);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }
    /// <summary>
    /// Executes an action when the result is successful, converting exceptions to failures using a rich error mapper.
    /// </summary>
    public static Result<TValue> TapTry<TValue>(this Result<TValue> result, Action<TValue> action, Func<Exception, IError> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(() => action(result.Value), errorHandler);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }
    /// <summary>
    /// Executes an action when the result is successful, converting exceptions to failures using a rich multi-error mapper.
    /// </summary>
    public static Result<TValue> TapTry<TValue>(this Result<TValue> result, Action<TValue> action, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(() => action(result.Value), errorHandler);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }
}
