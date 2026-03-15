namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a check asynchronously when the condition is true.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">The condition that controls whether the operation runs.</param>
    /// <param name="check">The check to execute when the condition is satisfied.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the result of the asynchronous check.</returns>
    public static ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        bool condition,
        Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        return condition ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Executes a check asynchronously when the condition is true.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">The condition that controls whether the operation runs.</param>
    /// <param name="check">The check to execute when the condition is satisfied.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the result of the asynchronous check.</returns>
    public static ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        bool condition,
        Func<TValue, ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        return condition ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Executes a check asynchronously when the predicate evaluates to true for the result value.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">The predicate that controls whether the operation runs.</param>
    /// <param name="check">The check to execute when the condition is satisfied.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the result of the asynchronous check.</returns>
    public static ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        return result.IsSuccess && predicate(result.Value) ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Executes a check asynchronously when the predicate evaluates to true for the result value.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">The predicate that controls whether the operation runs.</param>
    /// <param name="check">The check to execute when the condition is satisfied.</param>
    /// <returns>A task that returns the original result when the condition is not met; otherwise the result of the asynchronous check.</returns>
    public static ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<TValue, ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        return result.IsSuccess && predicate(result.Value) ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }
}
