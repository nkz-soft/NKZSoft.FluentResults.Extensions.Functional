namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a check asynchronously when the condition is true for the awaited result.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="condition">The condition that controls whether the operation runs.</param>
    /// <param name="check">The check to execute when the condition is satisfied.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the result of the asynchronous check.</returns>
    public static async Task<Result<TValue>> CheckIfAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        bool condition,
        Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return result.CheckIf(condition, check);
    }

    /// <summary>
    /// Executes a check asynchronously when the condition is true for the awaited result.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="condition">The condition that controls whether the operation runs.</param>
    /// <param name="check">The check to execute when the condition is satisfied.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the result of the asynchronous check.</returns>
    public static async Task<Result<TValue>> CheckIfAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        bool condition,
        Func<TValue, Result> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return result.CheckIf(condition, check);
    }

    /// <summary>
    /// Executes a check asynchronously when the predicate evaluates to true for the result value.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="predicate">The predicate that controls whether the operation runs.</param>
    /// <param name="check">The check to execute when the condition is satisfied.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the result of the asynchronous check.</returns>
    public static async Task<Result<TValue>> CheckIfAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, bool> predicate,
        Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return result.CheckIf(predicate, check);
    }

    /// <summary>
    /// Executes a check asynchronously when the predicate evaluates to true for the result value.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="predicate">The predicate that controls whether the operation runs.</param>
    /// <param name="check">The check to execute when the condition is satisfied.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the result of the asynchronous check.</returns>
    public static async Task<Result<TValue>> CheckIfAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, bool> predicate,
        Func<TValue, Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return result.CheckIf(predicate, check);
    }
}
