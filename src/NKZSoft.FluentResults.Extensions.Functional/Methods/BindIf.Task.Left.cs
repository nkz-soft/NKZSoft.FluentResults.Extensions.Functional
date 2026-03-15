namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Conditionally binds the result of an asynchronous operation.
    /// </summary>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="condition">The condition that controls whether the operation runs.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the bound result.</returns>
    public static async Task<Result> BindIfAsync(this Task<Result> resultTask, bool condition, Func<Result> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindIf(condition, func);
    }

    /// <summary>
    /// Conditionally binds the result of an asynchronous operation.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="condition">The condition that controls whether the operation runs.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the bound result.</returns>
    public static async Task<Result<TValue>> BindIfAsync<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<TValue, Result<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindIf(condition, func);
    }

    /// <summary>
    /// Conditionally binds the result when the predicate evaluates to true.
    /// </summary>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="predicate">The predicate that controls whether the operation runs.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the bound result.</returns>
    public static async Task<Result> BindIfAsync(this Task<Result> resultTask, Func<bool> predicate, Func<Result> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindIf(predicate, func);
    }

    /// <summary>
    /// Conditionally binds the result when the predicate evaluates to true.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="predicate">The predicate that controls whether the operation runs.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the bound result.</returns>
    public static async Task<Result<TValue>> BindIfAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<TValue, Result<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindIf(predicate, func);
    }
}
