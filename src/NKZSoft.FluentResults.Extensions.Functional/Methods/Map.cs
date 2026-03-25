namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Projects a successful result into a new successful result value.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the mapped result.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The projection to run when the source result is successful.</param>
    /// <returns>A successful result containing the projected value, or a failed result that preserves the original errors.</returns>
    public static Result<TValue> Map<TValue>(this Result result, Func<TValue> func)
        => result.IternalMap(func);

    /// <summary>
    /// Projects a successful result value into a new successful result value.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the source result.</typeparam>
    /// <typeparam name="TValueOut">The type carried by the mapped result.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The projection to run with the successful source value.</param>
    /// <returns>A successful result containing the projected value, or a failed result that preserves the original errors.</returns>
    public static Result<TValueOut> Map<TValue, TValueOut>(this Result<TValue> result, Func<TValue, TValueOut> func)
        => result.IternalMap(func);

    internal static Result<TValue> IternalMap<TValue>(this Result result, Func<TValue> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed ? Result.Fail<TValue>(result.Errors) : Result.Ok(func());
    }

    internal static Result<TValueOut> IternalMap<TValue, TValueOut>(this Result<TValue> result, Func<TValue, TValueOut> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed ? Result.Fail<TValueOut>(result.Errors) : Result.Ok(func(result.Value));
    }
}
