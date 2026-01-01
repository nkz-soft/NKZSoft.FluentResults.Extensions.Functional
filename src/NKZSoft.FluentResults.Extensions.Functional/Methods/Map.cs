namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Creates a new Result from the return value of a function.
    /// If the current Result is failed, returns a failed Result with the same errors.
    /// </summary>
    /// <typeparam name="TValue">The type of the value returned by the function.</typeparam>
    /// <param name="result">The Result to map.</param>
    /// <param name="func">The function to apply if the Result is successful.</param>
    /// <returns>A new Result containing the mapped value or the original errors.</returns>
    public static Result<TValue> Map<TValue>(this Result result, Func<TValue> func)
        => result.IternalMap(func);

    /// <summary>
    /// Creates a new Result from the return value of a function.
    /// If the current Result is failed, returns a failed Result with the same errors.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the Result.</typeparam>
    /// <typeparam name="TValueOut">The type of the value returned by the function.</typeparam>
    /// <param name="result">The Result to map.</param>
    /// <param name="func">The function to apply to the Result value if successful.</param>
    /// <returns>A new Result containing the mapped value or the original errors.</returns>
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
