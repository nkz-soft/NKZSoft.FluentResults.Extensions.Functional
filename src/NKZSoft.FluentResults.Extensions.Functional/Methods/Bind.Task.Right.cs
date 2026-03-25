namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Chains the next asynchronous operation to a successful result.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The asynchronous operation to run when the source result is successful.</param>
    /// <returns>A task that returns the next result, or a failed result that preserves the original errors.</returns>
    public static Task<Result> BindAsync(this Result result, Func<Task<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed ? Task.FromResult(Result.Fail(result.Errors)) : func();
    }

    /// <summary>
    /// Chains the next asynchronous operation to a successful result value.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the source result.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The asynchronous operation to run with the successful source value.</param>
    /// <returns>A task that returns the next result, or a failed result that preserves the original errors.</returns>
    public static Task<Result<TValue>> BindAsync<TValue>(this Result<TValue> result, Func<TValue, Task<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed ? Task.FromResult(Result.Fail<TValue>(result.Errors)) : func(result.Value);
    }
}
