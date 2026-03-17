namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapErrorIfAsync(this ValueTask<Result> resultTask, bool condition, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapErrorIf(condition, action);
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapErrorIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapErrorIf(condition, action);
    }

    /// <summary>
    /// Executes an action for each error when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute for each error.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapErrorIfAsync(this ValueTask<Result> resultTask, bool condition, Action<IError> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapErrorIf(condition, action);
    }

    /// <summary>
    /// Executes an action for each error when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute for each error.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapErrorIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Action<IError> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapErrorIf(condition, action);
    }
}
