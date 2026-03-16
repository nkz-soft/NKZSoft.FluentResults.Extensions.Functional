namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action when the supplied condition is true and the awaited result is successful.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result> TapIfAsync(this Task<Result> resultTask, bool condition, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIf(condition, action);
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result<TValue>> TapIfAsync<TValue>(this Task<Result<TValue>> resultTask, bool condition, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIf(condition, action);
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result<TValue>> TapIfAsync<TValue>(this Task<Result<TValue>> resultTask, bool condition, Action<TValue> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIf(condition, action);
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the awaited result is successful.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result> TapIfAsync(this Task<Result> resultTask, Func<bool> predicate, Action action)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIf(predicate, action);
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result<TValue>> TapIfAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> predicate, Action action)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIf(predicate, action);
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task<Result<TValue>> TapIfAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> predicate, Action<TValue> action)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapIf(predicate, action);
    }
}
