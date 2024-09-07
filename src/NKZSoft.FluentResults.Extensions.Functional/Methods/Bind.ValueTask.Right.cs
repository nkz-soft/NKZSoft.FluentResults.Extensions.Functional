namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Binds a function that returns a Task of Result to the current Result.
    /// If the current Result is failed, returns a failed Result with the same errors.
    /// Otherwise, executes the function and returns its result.
    /// </summary>
    /// <param name="result">The current Result.</param>
    /// <param name="func">The function to bind to the current Result.</param>
    /// <returns>A Task of Result.</returns>
    public static ValueTask<Result> BindAsync(this Result result, Func<ValueTask<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed ? ValueTask.FromResult(Result.Fail(result.Errors)) : func();
    }

    /// <summary>
    /// Binds a result to a function that returns a new result asynchronously.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the result.</typeparam>
    /// <param name="result">The result to bind.</param>
    /// <param name="func">The function that returns a new result.</param>
    /// <returns>A task that returns the bound result.</returns>
    public static ValueTask<Result<TValue>> BindAsync<TValue>(this Result<TValue> result, Func<TValue, ValueTask<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.IsFailed ? ValueTask.FromResult(Result.Fail<TValue>(result.Errors)) : func(result.Value);
    }
}
