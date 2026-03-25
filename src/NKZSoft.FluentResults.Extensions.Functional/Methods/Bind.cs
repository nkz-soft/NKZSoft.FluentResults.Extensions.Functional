namespace NKZSoft.FluentResults.Extensions.Functional;

/// <summary>
/// Provides functional composition extensions for <see cref="Result"/> and <see cref="Result{TValue}"/>.
/// </summary>
public static partial class ResultExtensions
{
    /// <summary>
    /// Chains the next operation to a successful result.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The operation to run when the source result is successful.</param>
    /// <returns>The next result produced by <paramref name="func"/>, or the original failed result when the source result is failed.</returns>
    public static Result Bind(this Result result, Func<Result> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IternalBind(func);
    }

    /// <summary>
    /// Chains the next operation to a successful result.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the chained result.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The operation to run when the source result is successful.</param>
    /// <returns>The next result produced by <paramref name="func"/>, or a failed result that preserves the original errors.</returns>
    public static Result<TValue> Bind<TValue>(this Result result, Func<Result<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed ? Result.Fail<TValue>(result.Errors) : func();
    }

    /// <summary>
    /// Chains the next operation to a successful result value.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the source result.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The operation to run with the successful source value.</param>
    /// <returns>The next result produced by <paramref name="func"/>, or the original failed result when the source result is failed.</returns>
    public static Result Bind<TValue>(this Result<TValue> result, Func<TValue, Result> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed ? Result.Fail(result.Errors) : func(result.Value);
    }

    /// <summary>
    /// Chains the next operation to a successful result value.
    /// </summary>
    /// <typeparam name="TInput">The type carried by the source result.</typeparam>
    /// <typeparam name="TOutput">The type carried by the chained result.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The operation to run with the successful source value.</param>
    /// <returns>The next result produced by <paramref name="func"/>, or a failed result that preserves the original errors.</returns>
    public static Result<TOutput> Bind<TInput, TOutput>(this Result<TInput> result, Func<TInput, Result<TOutput>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed ? Result.Fail<TOutput>(result.Errors) : func(result.Value);
    }

    /// <summary>
    /// Binds a function to a Result, executing it only if the Result is successful.
    /// </summary>
    /// <param name="result">The Result to bind the function to.</param>
    /// <param name="func">The function to bind to the Result.</param>
    /// <returns>A new Result that is the result of executing the bound function, or the original failed Result if it was failed.</returns>
    internal static Result IternalBind(this Result result, Func<Result> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        return  result.IsFailed ? result : func();
    }


    /// <summary>
    /// Binds a function to a Result, executing it only if the Result is successful.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the Result.</typeparam>
    /// <param name="result">The Result to bind the function to.</param>
    /// <param name="func">The function to bind to the Result. This function takes the value from the Result and returns a new Result.</param>
    /// <returns>A new Result that is the result of executing the bound function, or the original failed Result if it was failed.</returns>
    internal static Result<TValue> IternalBind<TValue>(this Result<TValue> result, Func<TValue, Result<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed ? result : func(result.Value);
    }
}
