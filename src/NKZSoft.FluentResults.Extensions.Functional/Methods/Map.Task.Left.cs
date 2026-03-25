namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Awaits the source result and projects it with a synchronous mapping when it succeeds.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the mapped result.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The projection to run when the awaited result is successful.</param>
    /// <returns>A task that returns the projected result, or the original failure from the awaited result.</returns>
    public static async Task<Result<TValue>> MapAsync<TValue>(this Task<Result> resultTask, Func<TValue> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.IternalMap(func);
    }

    /// <summary>
    /// Awaits the source result and projects it with a synchronous mapping when it succeeds.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the source result.</typeparam>
    /// <typeparam name="TValueOut">The type carried by the mapped result.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The projection to run with the successful source value.</param>
    /// <returns>A task that returns the projected result, or the original failure from the awaited result.</returns>
    public static async Task<Result<TValueOut>> MapAsync<TValue, TValueOut>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, TValueOut> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.IternalMap(func);
    }
}
