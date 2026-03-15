namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Conditionally binds the result with a synchronous function.
    /// </summary>
    public static Result BindIf(this Result result, bool condition, Func<Result> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.Bind(func) : result;
    }

    /// <summary>
    /// Conditionally binds the result value with a synchronous function.
    /// </summary>
    public static Result<TValue> BindIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, Result<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.Bind(func) : result;
    }

    /// <summary>
    /// Binds the result with a synchronous function when predicate evaluates to true.
    /// </summary>
    public static Result BindIf(this Result result, Func<bool> predicate, Func<Result> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate()
            ? result.Bind(func)
            : result;
    }

    /// <summary>
    /// Binds the result value with a synchronous function when predicate evaluates to true.
    /// </summary>
    public static Result<TValue> BindIf<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<TValue, Result<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate(result.Value)
            ? result.Bind(func)
            : result;
    }
}
