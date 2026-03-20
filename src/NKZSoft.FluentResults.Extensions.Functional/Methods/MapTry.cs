namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps a successful result and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The type of the mapped value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The mapping function.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A mapped successful result, the original failure, or a failed result created from a thrown exception.</returns>
    public static Result<TValue> MapTry<TValue>(this Result result, Func<TValue> func, Func<Exception, string>? errorHandler = null)
        => result.InternalMapTry(func, errorHandler);
    /// <summary>
    /// Maps a successful result and converts thrown exceptions into failed results using a rich error mapper.
    /// </summary>
    public static Result<TValue> MapTry<TValue>(this Result result, Func<TValue> func, Func<Exception, IError> errorHandler)
        => result.InternalMapTry(func, errorHandler);
    /// <summary>
    /// Maps a successful result and converts thrown exceptions into failed results using a rich multi-error mapper.
    /// </summary>
    public static Result<TValue> MapTry<TValue>(this Result result, Func<TValue> func, Func<Exception, IEnumerable<IError>> errorHandler)
        => result.InternalMapTry(func, errorHandler);

    /// <summary>
    /// Maps a successful result and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The source value type.</typeparam>
    /// <typeparam name="TValueOut">The type of the mapped value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The mapping function.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>A mapped successful result, the original failure, or a failed result created from a thrown exception.</returns>
    public static Result<TValueOut> MapTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, TValueOut> func,
        Func<Exception, string>? errorHandler = null)
        => result.InternalMapTry(func, errorHandler);
    /// <summary>
    /// Maps a successful result and converts thrown exceptions into failed results using a rich error mapper.
    /// </summary>
    public static Result<TValueOut> MapTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, TValueOut> func,
        Func<Exception, IError> errorHandler)
        => result.InternalMapTry(func, errorHandler);
    /// <summary>
    /// Maps a successful result and converts thrown exceptions into failed results using a rich multi-error mapper.
    /// </summary>
    public static Result<TValueOut> MapTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, TValueOut> func,
        Func<Exception, IEnumerable<IError>> errorHandler)
        => result.InternalMapTry(func, errorHandler);

    internal static Result<TValue> InternalMapTry<TValue>(
        this Result result,
        Func<TValue> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed
            ? Result.Fail<TValue>(result.Errors)
            : Try(func, errorHandler);
    }
    internal static Result<TValue> InternalMapTry<TValue>(
        this Result result,
        Func<TValue> func,
        Func<Exception, IError> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? Result.Fail<TValue>(result.Errors)
            : Try(func, errorHandler);
    }
    internal static Result<TValue> InternalMapTry<TValue>(
        this Result result,
        Func<TValue> func,
        Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? Result.Fail<TValue>(result.Errors)
            : Try(func, errorHandler);
    }

    internal static Result<TValueOut> InternalMapTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, TValueOut> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed
            ? Result.Fail<TValueOut>(result.Errors)
            : Try(() => func(result.Value), errorHandler);
    }
    internal static Result<TValueOut> InternalMapTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, TValueOut> func,
        Func<Exception, IError> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? Result.Fail<TValueOut>(result.Errors)
            : Try(() => func(result.Value), errorHandler);
    }
    internal static Result<TValueOut> InternalMapTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, TValueOut> func,
        Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? Result.Fail<TValueOut>(result.Errors)
            : Try(() => func(result.Value), errorHandler);
    }
}
