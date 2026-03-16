namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the awaited result is successful.
    /// </summary>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapIfAsync(this ValueTask<Result> resultTask, bool condition, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the awaited result is successful.
    /// </summary>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapIfAsync(this ValueTask<Result> resultTask, bool condition, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<TValue, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<TValue, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied predicate evaluates to true and the awaited result is successful.
    /// </summary>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapIfAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(predicate, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied predicate evaluates to true and the awaited result is successful.
    /// </summary>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result> TapIfAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(predicate, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied predicate evaluates to true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(predicate, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied predicate evaluates to true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(predicate, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied predicate evaluates to true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<TValue, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(predicate, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a task function when the supplied predicate evaluates to true and the awaited result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">The valuetask producing the result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static async ValueTask<Result<TValue>> TapIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<TValue, Task> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapIfAsync(predicate, func).ConfigureAwait(false);
    }
}
