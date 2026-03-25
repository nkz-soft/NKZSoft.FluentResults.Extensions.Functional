namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action if the result of the task is failed.
    /// </summary>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="action">The action to execute if the result is failed.</param>
    /// <returns>A task that completes with the original result after the callback finishes.</returns>
    public static async Task<Result> TapErrorAsync(this Task<Result> resultTask, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapError(action);
    }

    /// <summary>
    /// Executes an action if the result of the task is failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="action">The action to execute if the result is failed.</param>
    /// <returns>A task that completes with the original result after the callback finishes.</returns>
    public static async Task<Result<TValue>> TapErrorAsync<TValue>(this Task<Result<TValue>> resultTask, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapError(action);
    }

    /// <summary>
    /// Executes an action for each error if the result of the task is failed.
    /// </summary>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="action">The action to execute for each error.</param>
    /// <returns>A task that completes with the original result after the callback finishes.</returns>
    public static async Task<Result> TapErrorAsync(this Task<Result> resultTask, Action<IError> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapError(action);
    }

    /// <summary>
    /// Executes an action for each error if the result of the task is failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="action">The action to execute for each error.</param>
    /// <returns>A task that completes with the original result after the callback finishes.</returns>
    public static async Task<Result<TValue>> TapErrorAsync<TValue>(this Task<Result<TValue>> resultTask, Action<IError> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        return result.TapError(action);
    }
}
