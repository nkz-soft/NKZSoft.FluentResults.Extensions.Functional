namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Conditionally binds the result using an asynchronous function.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">The condition that controls whether the operation runs.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the bound result.</returns>
    public static Task<Result> BindIfAsync(this Result result, bool condition, Func<Task<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition
            ? result.BindAsync(func)
            : Task.FromResult(result);
    }

    /// <summary>
    /// Conditionally binds the result using an asynchronous function.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">The condition that controls whether the operation runs.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the bound result.</returns>
    public static Task<Result<TValue>> BindIfAsync<TValue>(this Result<TValue> result, bool condition, Func<TValue, Task<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition
            ? result.BindAsync(func)
            : Task.FromResult(result);
    }

    /// <summary>
    /// Conditionally binds the result when the predicate evaluates to true.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">The predicate that controls whether the operation runs.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the bound result.</returns>
    public static Task<Result> BindIfAsync(this Result result, Func<bool> predicate, Func<Task<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate()
            ? result.BindAsync(func)
            : Task.FromResult(result);
    }

    /// <summary>
    /// Conditionally binds the result when the predicate evaluates to true.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">The predicate that controls whether the operation runs.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the bound result.</returns>
    public static Task<Result<TValue>> BindIfAsync<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<TValue, Task<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate(result.Value)
            ? result.BindAsync(func)
            : Task.FromResult(result);
    }
}
