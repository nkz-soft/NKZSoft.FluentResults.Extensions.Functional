namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Binds a successful result and converts thrown exceptions into failed results.
    /// </summary>
    public static Result BindTry(this Result result, Func<Result> func, Func<Exception, string>? errorHandler = null)
        => result.InternalBindTry(func, errorHandler);
    public static Result BindTry(this Result result, Func<Result> func, Func<Exception, IError> errorHandler)
        => result.InternalBindTry(func, errorHandler);
    public static Result BindTry(this Result result, Func<Result> func, Func<Exception, IEnumerable<IError>> errorHandler)
        => result.InternalBindTry(func, errorHandler);

    /// <summary>
    /// Binds a successful result and converts thrown exceptions into failed results.
    /// </summary>
    public static Result<TValue> BindTry<TValue>(this Result result, Func<Result<TValue>> func, Func<Exception, string>? errorHandler = null)
        => result.InternalBindTry(func, errorHandler);
    public static Result<TValue> BindTry<TValue>(this Result result, Func<Result<TValue>> func, Func<Exception, IError> errorHandler)
        => result.InternalBindTry(func, errorHandler);
    public static Result<TValue> BindTry<TValue>(this Result result, Func<Result<TValue>> func, Func<Exception, IEnumerable<IError>> errorHandler)
        => result.InternalBindTry(func, errorHandler);

    /// <summary>
    /// Binds a successful result value and converts thrown exceptions into failed results.
    /// </summary>
    public static Result BindTry<TValue>(this Result<TValue> result, Func<TValue, Result> func, Func<Exception, string>? errorHandler = null)
        => result.InternalBindTry(func, errorHandler);
    public static Result BindTry<TValue>(this Result<TValue> result, Func<TValue, Result> func, Func<Exception, IError> errorHandler)
        => result.InternalBindTry(func, errorHandler);
    public static Result BindTry<TValue>(this Result<TValue> result, Func<TValue, Result> func, Func<Exception, IEnumerable<IError>> errorHandler)
        => result.InternalBindTry(func, errorHandler);

    /// <summary>
    /// Binds a successful result value and converts thrown exceptions into failed results.
    /// </summary>
    public static Result<TValueOut> BindTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Result<TValueOut>> func,
        Func<Exception, string>? errorHandler = null)
        => result.InternalBindTry(func, errorHandler);
    public static Result<TValueOut> BindTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Result<TValueOut>> func,
        Func<Exception, IError> errorHandler)
        => result.InternalBindTry(func, errorHandler);
    public static Result<TValueOut> BindTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Result<TValueOut>> func,
        Func<Exception, IEnumerable<IError>> errorHandler)
        => result.InternalBindTry(func, errorHandler);

    internal static Result InternalBindTry(this Result result, Func<Result> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed
            ? result
            : Try(func, errorHandler).Bind(static output => output);
    }
    internal static Result InternalBindTry(this Result result, Func<Result> func, Func<Exception, IError> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? result
            : Try(func, errorHandler).Bind(static output => output);
    }
    internal static Result InternalBindTry(this Result result, Func<Result> func, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? result
            : Try(func, errorHandler).Bind(static output => output);
    }

    internal static Result<TValue> InternalBindTry<TValue>(this Result result, Func<Result<TValue>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed
            ? Result.Fail<TValue>(result.Errors)
            : Try(func, errorHandler).Bind(static output => output);
    }
    internal static Result<TValue> InternalBindTry<TValue>(this Result result, Func<Result<TValue>> func, Func<Exception, IError> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? Result.Fail<TValue>(result.Errors)
            : Try(func, errorHandler).Bind(static output => output);
    }
    internal static Result<TValue> InternalBindTry<TValue>(this Result result, Func<Result<TValue>> func, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? Result.Fail<TValue>(result.Errors)
            : Try(func, errorHandler).Bind(static output => output);
    }

    internal static Result InternalBindTry<TValue>(this Result<TValue> result, Func<TValue, Result> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed
            ? Result.Fail(result.Errors)
            : Try(() => func(result.Value), errorHandler).Bind(static output => output);
    }
    internal static Result InternalBindTry<TValue>(this Result<TValue> result, Func<TValue, Result> func, Func<Exception, IError> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? Result.Fail(result.Errors)
            : Try(() => func(result.Value), errorHandler).Bind(static output => output);
    }
    internal static Result InternalBindTry<TValue>(this Result<TValue> result, Func<TValue, Result> func, Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? Result.Fail(result.Errors)
            : Try(() => func(result.Value), errorHandler).Bind(static output => output);
    }

    internal static Result<TValueOut> InternalBindTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Result<TValueOut>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed
            ? Result.Fail<TValueOut>(result.Errors)
            : Try(() => func(result.Value), errorHandler).Bind(static output => output);
    }
    internal static Result<TValueOut> InternalBindTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Result<TValueOut>> func,
        Func<Exception, IError> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? Result.Fail<TValueOut>(result.Errors)
            : Try(() => func(result.Value), errorHandler).Bind(static output => output);
    }
    internal static Result<TValueOut> InternalBindTry<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Result<TValueOut>> func,
        Func<Exception, IEnumerable<IError>> errorHandler)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed
            ? Result.Fail<TValueOut>(result.Errors)
            : Try(() => func(result.Value), errorHandler).Bind(static output => output);
    }
}
