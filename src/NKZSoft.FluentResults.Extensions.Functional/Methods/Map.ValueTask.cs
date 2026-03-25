namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Awaits the source result and projects it with an asynchronous mapping when it succeeds.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the mapped result.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The asynchronous projection to run when the awaited result is successful.</param>
    /// <returns>A value task that returns the projected result, or the original failure from the awaited result.</returns>
    public static async ValueTask<Result<TValue>> MapAsync<TValue>(
        this ValueTask<Result> resultTask,
        Func<ValueTask<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Awaits the source result and projects it with an asynchronous mapping when it succeeds.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the mapped result.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The asynchronous projection to run when the awaited result is successful.</param>
    /// <returns>A value task that returns the projected result, or the original failure from the awaited result.</returns>
    public static async ValueTask<Result<TValue>> MapAsync<TValue>(
        this ValueTask<Result> resultTask,
        Func<Task<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Awaits the source result and projects it with an asynchronous mapping when it succeeds.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the source result.</typeparam>
    /// <typeparam name="TValueOut">The type carried by the mapped result.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The asynchronous projection to run with the successful source value.</param>
    /// <returns>A value task that returns the projected result, or the original failure from the awaited result.</returns>
    public static async ValueTask<Result<TValueOut>> MapAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, ValueTask<TValueOut>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Awaits the source result and projects it with an asynchronous mapping when it succeeds.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the source result.</typeparam>
    /// <typeparam name="TValueOut">The type carried by the mapped result.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The asynchronous projection to run with the successful source value.</param>
    /// <returns>A value task that returns the projected result, or the original failure from the awaited result.</returns>
    public static async ValueTask<Result<TValueOut>> MapAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, Task<TValueOut>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapAsync(func).ConfigureAwait(false);
    }
}
