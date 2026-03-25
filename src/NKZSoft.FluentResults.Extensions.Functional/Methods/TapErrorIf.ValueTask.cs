namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async ValueTask<Result> TapErrorIfAsync(this ValueTask<Result> resultTask, bool condition, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async ValueTask<Result> TapErrorIfAsync(this ValueTask<Result> resultTask, bool condition, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async ValueTask<Result<TValue>> TapErrorIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async ValueTask<Result<TValue>> TapErrorIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a valuetask function for each error when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute for each error.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async ValueTask<Result> TapErrorIfAsync(this ValueTask<Result> resultTask, bool condition, Func<IError, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function for each error when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute for each error.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async ValueTask<Result> TapErrorIfAsync(this ValueTask<Result> resultTask, bool condition, Func<IError, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a valuetask function for each error when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute for each error.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async ValueTask<Result<TValue>> TapErrorIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<IError, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function for each error when the supplied condition is true and the awaited result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The task producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute for each error.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static async ValueTask<Result<TValue>> TapErrorIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<IError, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorIfAsync(condition, func).ConfigureAwait(false);
    }
}
